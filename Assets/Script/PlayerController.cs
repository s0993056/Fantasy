using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerController : MonoBehaviour
{
    #region ��ư�
    Rigidbody2D rigid2D;
    Animator animator;
    [SerializeField]
    private PhysicsMaterial2D ground;//�����O5
    [SerializeField]
    private PhysicsMaterial2D air;//�����O0
    [SerializeField]
    private float jumpForce = 1400f;
    [SerializeField]
    private float maxSpeed = 12f;
    private float walkForce = 160f;//�_�B�t��
    static string trigger = "Idle";
    public static int events = 0;
    int LR = 0;//���k½��
    #endregion
    void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void TriggerChange(Trigger t)// �ʵe����
    {
        //if ((Trigger)Enum.Parse(typeof(Trigger), trigger) < t||!Input.anyKeyDown)
        if(t.ToString()!=trigger)
        {
            //print($"{trigger} {(int)(Trigger)Enum.Parse(typeof(Trigger), trigger)} {t}");
            animator.ResetTrigger(trigger);
            trigger = t.ToString();
            animator.SetTrigger(trigger);
        }
    }
    void FixedUpdate()
    {
        #region ���k����
        float speed = Mathf.Abs(rigid2D.velocity.x);
        if (speed < maxSpeed && (Step)GameController.step >= Step.Run && events == 0)
        {
            if (Input.GetKey(KeyCode.RightArrow))rigid2D.AddForce(transform.right * walkForce);
            if (Input.GetKey(KeyCode.LeftArrow)) rigid2D.AddForce(transform.right * walkForce * -1);
            if (Input.anyKey &&speed!=0)print(rigid2D.velocity.x);
        }
        #endregion        
        #region ���A������
        /*if (trigger == "Jump" && Mathf.Abs(rigid2D.velocity.y) < 1e-4f)
        rigid2D.AddForce(transform.up * jumpForce);*/
        #endregion
    }
    void Update()
    {
        if (!Input.anyKey && !animator.GetCurrentAnimatorStateInfo(0).IsName("jump") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Fall")) TriggerChange(Trigger.Idle);
        #region ���k����
        if (Input.GetKey(KeyCode.LeftArrow) && (Step)GameController.step >= Step.Run && events == 0)
        {
            LR = -1;
            if (trigger == "Idle") TriggerChange(Trigger.Run);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) )
        {
            rigid2D.AddForce(transform.right * rigid2D.velocity.x * -2);//�b��
        }

        if (Input.GetKey(KeyCode.RightArrow) && (Step)GameController.step >= Step.Run && events == 0)
        {
            LR = 1;
            if (trigger == "Idle") TriggerChange(Trigger.Run);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rigid2D.AddForce(transform.right * rigid2D.velocity.x * -2);//�b��
        }
        #endregion
        #region ���D���d��
        RaycastHit2D info = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y - 1.5501f), -Vector2.up, 0.3f);
        if (info.collider == null) { rigid2D.sharedMaterial = air; }
        else
        {
            rigid2D.sharedMaterial = ground;
        if (Mathf.Abs(rigid2D.velocity.y) > 1e-4f)rigid2D.AddForce(transform.right * rigid2D.velocity.x * -5);//�b��
        }
        #endregion
        #region ���A������
        if (Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(rigid2D.velocity.y) < 1e-4f
            && (Step)GameController.step >= Step.Jump)
        {
            TriggerChange(Trigger.Jump); 
            rigid2D.AddForce(transform.up * jumpForce);
        }
        if (rigid2D.velocity.y < -0.1)
            TriggerChange(Trigger.Fall);
        if (trigger == "Fall" && Mathf.Abs(rigid2D.velocity.y) < 1e-4f)
            TriggerChange(Trigger.Idle);
        #endregion
        if (Conversation.Talk[GameController.clickNumber].Say == "crystal") LR = -1;//�p���F�X�{�ਭ
        if (LR != 0)//�ਭ
            transform.localScale = new Vector3(LR, 1, 1);
    }
    void OnTriggerEnter2D(Collider2D other)//���w�ϰ�
    {
        if (other.gameObject.tag == "jump" && Conversation.Talk[GameController.clickNumber].Say == "walk")
            events = 1;
        if (other.gameObject.tag == "land" && Conversation.Talk[GameController.clickNumber].Say == "jump")
            events = 2;
    }
}
enum Trigger// �ʵe����
{
    Idle, Run, Hurt, Attcak, Jump, Fall
}
