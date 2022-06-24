using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
	#region 資料區
	Rigidbody2D rigid2D;
	Animator animator;
	[SerializeField]
	private PhysicsMaterial2D ground;//摩擦力3
	[SerializeField]
	private PhysicsMaterial2D air;//摩擦力0
	[SerializeField]
	private float jumpForce = 1400f;
	[SerializeField]
	private float maxSpeed = 12f;
	private float walkForce = 160f;//起步速度
	static string trigger = "Idle";
	public static int events = 0;
	int LR = 0;//左右翻轉
	bool onGround = true;//是否在地上//拋物線跳躍用
	public static int Attacking = 0;//是否攻擊中
	float attackTime = 0;//攻擊時間0.58
	bool hurt=false;
	float hurtTime = 0;//攻擊時間0.58
	#endregion

	GameController hp = new GameController();///////
	void Awake()
	{
		rigid2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	/// <summary>
	/// 動畫切換
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
	/// 偵測動畫撥放
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
	void FixedUpdate()
	{
		#region 左右控制
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
		//閒置
		if (Mathf.Abs(rigid2D.velocity.x) < 1e-4f && AminatorTrigger(Trigger.Idle))
			TriggerChange(Trigger.Idle);
		if (attackTime > 0)//攻擊計時
		{
			attackTime -= Time.deltaTime;
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
				Attacking = 1;
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack2"))
				Attacking = 2;
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack3"))
				Attacking = 3;
		}
		else if (attackTime < 0.0001f)//攻擊結束------------
		{
			TriggerChange(Trigger.Idle);
			Attacking = 0;
			GameController.HP = 100;
		}
		#region 左右控制
		if (Input.GetKey(KeyCode.LeftArrow) && (Step)GameController.step >= Step.Run && AminatorTrigger(Trigger.Jump))
		{
			LR = -1;
			if (trigger == "Idle") TriggerChange(Trigger.Run);
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
			rigid2D.AddForce(transform.right * rigid2D.velocity.x * -2);//剎車
		}

		if (Input.GetKey(KeyCode.RightArrow) && (Step)GameController.step >= Step.Run && AminatorTrigger(Trigger.Jump))
		{
			LR = 1;
			if (trigger == "Idle") TriggerChange(Trigger.Run);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow))
		{
			rigid2D.AddForce(transform.right * rigid2D.velocity.x * -2);//剎車
		}
		#endregion
		#region 攻擊
		if (Input.GetKeyDown(KeyCode.D) && (Step)GameController.step >= Step.Attack &&
			AminatorTrigger(Trigger.Attack))
		{
			TriggerChange(Trigger.Attack);
			attackTime = 0.56f;
		}
		#endregion
		#region 跳躍不卡牆
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
			if (rigid2D.velocity.y < -1e-4f) rigid2D.AddForce(transform.right * rigid2D.velocity.x * -3);//剎車
		}
		#endregion
		#region 跳，落控制
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
        #region 受傷
        if (hurt)
		{
			if (hurtTime == 1)
				TriggerChange(Trigger.Hurt);
			if (hurtTime > 0) hurtTime -= Time.deltaTime;
			if (hurtTime < 0) hurtTime=1;
				GameController.HP = 0;
		}
        #endregion
        if (Conversation.Talk[GameController.clickNumber].Say == "crystal") LR = -1;//小精靈出現轉身
		if (LR != 0)//轉身
			transform.localScale = new Vector3(LR, 1, 1);

	}
	/// <summary>
	/// 指定區域
	/// </summary>
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "jump" && Conversation.Talk[GameController.clickNumber].Say == "walk" ||
			other.gameObject.tag == "land" && Conversation.Talk[GameController.clickNumber].Say == "jump" ||
			other.gameObject.tag == "attack" && Conversation.Talk[GameController.clickNumber].Say == "chest")
			events = 1;
	}
    #region 受傷碰撞
    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "monster")
		{
			hurt = true;
			hurtTime = 1;
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
		}

	}
	#endregion
}
/// <summary>
/// 動畫Trigger
/// </summary>
enum Trigger
{
	Idle, Run, Hurt, Attack, Jump, Fall
}
