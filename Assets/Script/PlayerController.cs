using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    #region 資料區
    Rigidbody2D rigid2D;
    Animator animator;
    [SerializeField]
    private PhysicsMaterial2D ground;//摩擦力5
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
    bool onGround = true;
    #endregion
    void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void TriggerChange(Trigger t)// 動畫切換
    {
        if(t.ToString()!=trigger)
        {
            animator.ResetTrigger(trigger);
            trigger = t.ToString();
            animator.SetTrigger(trigger);
        }
    }
    void FixedUpdate()
    {               
        #region 左右控制
        float speed = rigid2D.velocity.x;
        if ( (Step)GameController.step >= Step.Run && events == 0)
        {
            if (speed < maxSpeed && Input.GetKey(KeyCode.RightArrow)&&(onGround||speed>-3))
                rigid2D.AddForce(transform.right * walkForce);
            if (speed > -maxSpeed && Input.GetKey(KeyCode.LeftArrow) && (onGround || speed <3)) 
                rigid2D.AddForce(transform.right * walkForce * -1);
        }
        #endregion 
    }
    void Update()
    {
        //閒置
        if (!Input.anyKey && !animator.GetCurrentAnimatorStateInfo(0).IsName("jump") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Fall")) 
            TriggerChange(Trigger.Idle);
        #region 左右控制
        if (Input.GetKey(KeyCode.LeftArrow) && (Step)GameController.step >= Step.Run && events == 0)
        {
            LR = -1;
            if (trigger == "Idle") TriggerChange(Trigger.Run);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) )
        {
            rigid2D.AddForce(transform.right * rigid2D.velocity.x * -2);//剎車
        }

        if (Input.GetKey(KeyCode.RightArrow) && (Step)GameController.step >= Step.Run && events == 0)
        {
            LR = 1;
            if (trigger == "Idle") TriggerChange(Trigger.Run);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rigid2D.AddForce(transform.right * rigid2D.velocity.x * -2);//剎車
        }
        #endregion
        #region 跳躍不卡牆
        RaycastHit2D info = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y - 1.5501f), -Vector2.up, 0.3f);
        if (info.collider == null)
        {
            rigid2D.sharedMaterial = air;
            onGround =false;
        }
        else
        {
            rigid2D.sharedMaterial = ground;
            onGround = true;
            if (rigid2D.velocity.y < -1e-4f)rigid2D.AddForce(transform.right * rigid2D.velocity.x * -10);//剎車
        }
        #endregion
        #region 跳，落控制
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
        if (Conversation.Talk[GameController.clickNumber].Say == "crystal") LR = -1;//小精靈出現轉身
        if (LR != 0)//轉身
            transform.localScale = new Vector3(LR, 1, 1);
    }
    void OnTriggerEnter2D(Collider2D other)//指定區域
    {
        if (other.gameObject.tag == "jump" && Conversation.Talk[GameController.clickNumber].Say == "walk")
            events = 1;
        if (other.gameObject.tag == "land" && Conversation.Talk[GameController.clickNumber].Say == "jump")
            events = 2;
    }
}
enum Trigger// 動畫切換
{
    Idle, Run, Hurt, Attcak, Jump, Fall
}
