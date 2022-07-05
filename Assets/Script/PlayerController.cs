using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
	#region ��ư�
	Rigidbody2D rigid2D;
	Animator animator;
	public Vector2 position { get; private set; }
	[SerializeField]
	private PhysicsMaterial2D ground;//�����O3
	[SerializeField]
	private PhysicsMaterial2D air;//�����O0
	[SerializeField]
	private float jumpForce = 1400f;
	[SerializeField]
	private float maxSpeed = 12f;
	[SerializeField]
	private AudioClip attack1;
	[SerializeField]
	private AudioClip attack3;
	AudioSource audio;
	private float walkForce = 160f;//�_�B�t��
	static string trigger = "Idle";
	public static int LR = 0;//���k½��
	bool onGround = true;//�O�_�b�a�W//�ߪ��u���D��
	public static int Attacking = 0;//�O�_������
	float attackTime = 0;//�����ɶ�0.58
	bool hurt=false;
	float hurtTime = 0;//�����ɶ�0.58
	int Hurt = 0;
	public static bool events = false;
	#endregion

	GameController hp = new GameController();///////
	void Awake()
	{
		rigid2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		audio=GetComponent<AudioSource>();
		transform.position = new Vector2(PlayerPrefs.GetFloat("x",transform.position.x), PlayerPrefs.GetFloat("y", transform.position.y));
		if (GameController.clickNumber < 1)
			animator.Play("relife");
	}
	/// <summary>
	/// �ʵe����
	/// </summary>
	void TriggerChange(Trigger t)
	{
		if (t.ToString() != trigger)
		{
			animator.ResetTrigger(trigger);
			trigger = t.ToString();
			animator.SetTrigger(trigger);
		}
		else if (t == Trigger.Attack)
		{
			animator.ResetTrigger("Attack");
			trigger = "Attack";
			animator.SetTrigger(trigger);
		}
	}
	/// <summary>
	/// �����ʵe����
	/// </summary>
	bool AminatorTrigger(Trigger t) //
	{
		if (t != Trigger.Jump)
		{
			if (!animator.GetCurrentAnimatorStateInfo(0).IsName("jump") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Fall"))
			{
				if (t < Trigger.Attack)
				{
					if (!animator.GetCurrentAnimatorStateInfo(0).IsName("attack1") && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack2")
						&& !animator.GetCurrentAnimatorStateInfo(0).IsName("attack3"))
					{
						if (t < Trigger.Hurt)
						{
							if (!animator.GetCurrentAnimatorStateInfo(0).IsName("hurt"))
							{
								return true;
							}
							else return false;
						}
						else return true;
					}
					else return false;
				}
				else return true;
			}
			else return false;
		}
		else
		{
			return !animator.GetCurrentAnimatorStateInfo(0).IsName("hurt") && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack1") &&
				!animator.GetCurrentAnimatorStateInfo(0).IsName("attack2") && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack3");
		}
	}
	/// <summary>
	/// ��������
	/// </summary>
	void attackAudio(int a)
    {
		if (a == 0) audio.PlayOneShot(attack1);
		if (a == 1) audio.PlayOneShot(attack3);
	}
	void FixedUpdate()
	{
		#region ���k����
		float speed = rigid2D.velocity.x;
		if ((Step)GameController.step >= Step.Run && AminatorTrigger(Trigger.Jump))
		{
			if (speed < maxSpeed && Input.GetKey(KeyCode.RightArrow))
				rigid2D.AddForce(transform.right * walkForce);
			if (speed > -maxSpeed && Input.GetKey(KeyCode.LeftArrow))
				rigid2D.AddForce(transform.right * walkForce * -1);
		}
		#endregion
	}
	void Update()
	{
		//���m
		if (Mathf.Abs(rigid2D.velocity.x) < 1e-4f && AminatorTrigger(Trigger.Idle))
			TriggerChange(Trigger.Idle);
		if (attackTime > 0)//�����p��
		{
			attackTime -= Time.deltaTime;
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
				Attacking = 1;
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack2"))
				Attacking = 2;
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack3"))
				Attacking = 3;
		}
		else if (attackTime < 0.0001f)//��������------------
		{
			TriggerChange(Trigger.Idle);
			Attacking = 0;
		}
		#region ���k����
		if (Input.GetKey(KeyCode.LeftArrow) && (Step)GameController.step >= Step.Run && AminatorTrigger(Trigger.Jump))
		{
			LR = -1;
			if (trigger == "Idle") TriggerChange(Trigger.Run);
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
			rigid2D.AddForce(transform.right * rigid2D.velocity.x * -2);//�b��
		}

		if (Input.GetKey(KeyCode.RightArrow) && (Step)GameController.step >= Step.Run && AminatorTrigger(Trigger.Jump))
		{
			LR = 1;
			if (trigger == "Idle") TriggerChange(Trigger.Run);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow))
		{
			rigid2D.AddForce(transform.right * rigid2D.velocity.x * -2);//�b��
		}
		#endregion
		#region ����
		if (Input.GetKeyDown(KeyCode.D) && (Step)GameController.step >= Step.Attack &&
			AminatorTrigger(Trigger.Attack))
		{
			TriggerChange(Trigger.Attack);
			attackTime = 0.56f;
		}
		#endregion
		#region ���D���d��
		RaycastHit2D info = Physics2D.Raycast(
			new Vector2(transform.position.x, transform.position.y - 2.0001f), -Vector2.up, 0.1f);
		if (info.collider == null)
		{
			rigid2D.sharedMaterial = air;
			onGround = false;
		}
		else
		{
			rigid2D.sharedMaterial = ground;
			onGround = true;
			if (rigid2D.velocity.y < -1e-4f) rigid2D.AddForce(transform.right * rigid2D.velocity.x * -3);//�b��
		}
		#endregion
		#region ���A������
		if (Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(rigid2D.velocity.y) < 1e-4f
			&& (Step)GameController.step >= Step.Jump && AminatorTrigger(Trigger.Jump))
		{
			TriggerChange(Trigger.Jump);
			rigid2D.AddForce(transform.up * jumpForce);
		}
		if (rigid2D.velocity.y < -0.1)
			TriggerChange(Trigger.Fall);
		if (trigger == "Fall" && Mathf.Abs(rigid2D.velocity.y) < 1e-4f)
		{
			TriggerChange(Trigger.Idle);
		}
        #endregion
        #region ����
        if (hurt)
		{
			if (hurtTime == 1)
			{
				TriggerChange(Trigger.Hurt);
				GameController.HP -= Hurt;
			}
			if (hurtTime > 0) hurtTime -= Time.deltaTime;
			if (hurtTime < 0) hurtTime=1;
		}
        #endregion
        if (Conversation.Talk[GameController.clickNumber].Say == "crystal") LR = -1;//�p���F�X�{�ਭ
		if (LR != 0)//�ਭ
			transform.localScale = new Vector3(LR, 1, 1);

	}
	/// <summary>
	/// ���w�ϰ�
	/// </summary>
	void OnTriggerEnter2D(Collider2D other)
	{//��ܰϰ�
		if (other.gameObject.name == "jump" && Conversation.Talk[GameController.clickNumber].Say == "walk" ||
			other.gameObject.name == "land" && Conversation.Talk[GameController.clickNumber].Say == "jump" ||
			other.gameObject.name == "attack" && Conversation.Talk[GameController.clickNumber].Say == "chest" ||
			other.gameObject.name == "shop" && Conversation.Talk[GameController.clickNumber].Say == "attack"&&GameController.monsterNumber==0)
			events = true;

		if (other.gameObject.name == "attack" && Conversation.Talk[GameController.clickNumber].Say == "chest")////////////////////////
		{//position = transform.position;
			PlayerPrefs.SetFloat("x",transform.position.x);
			PlayerPrefs.SetFloat("y", transform.position.y);
		}
		//�}�c
		if (other.gameObject.tag == "chest")
		{
			other.GetComponent<Animator>().SetTrigger("Open");
		}
	}
    #region ���˸I��
    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "monster")
		{
			hurt = true;
			hurtTime = 1;
			Hurt = collision.gameObject.GetComponentInChildren<MonsterHurt>().attack;
		}
        
    }
    private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "monster")
		{
			hurt = true;
		}

	}
    private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "monster")
		{
			hurt = false;
			hurtTime = 0;
			Hurt = 0;
		}

	}
	#endregion
}
/// <summary>
/// �ʵeTrigger
/// </summary>
enum Trigger
{
	Idle, Run, Hurt, Attack, Jump, Fall
}
