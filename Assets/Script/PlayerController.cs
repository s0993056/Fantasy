using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerController : MonoBehaviour
{
    #region 資料區
    Rigidbody2D rigid2D;
    Animator animator;
    [SerializeField]
    private PhysicsMaterial2D ground;
    [SerializeField]
    private PhysicsMaterial2D air;
    [SerializeField]
    private float jumpForce = 1400f;
    private float walkForce = 30f;//起步速度
    [SerializeField]
    private float maxSpeed = 12f;
    static string trigger = "Idle";
    public static int events=0;
	#endregion
    void Awake()
    {
        rigid2D=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }
    void TriggerChange(Trigger t)// 動畫切換
    {
        if ((Trigger)Enum.Parse(typeof(Trigger), trigger) < t||!Input.anyKeyDown)
        {
            animator.ResetTrigger(trigger);
            trigger = t.ToString();
            animator.SetTrigger(trigger);
        }
    }
    void Update()
    {
        float speed = Mathf.Abs(rigid2D.velocity.x);
        int LR = 0;//左右翻轉
		#region 跳躍不卡牆
		RaycastHit2D info = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y - 1.5501f), -Vector2.up, 0.3f);
        if (info.collider == null) { rigid2D.sharedMaterial = air; }
        else
        {            
            rigid2D.sharedMaterial = ground;
            if (Mathf.Abs(rigid2D.velocity.y) > 1e-4f)
                rigid2D.AddForce(transform.right * rigid2D.velocity.x*-3);
        }        
        #endregion
        #region 跳，落控制
        if (Input.GetKeyDown(KeyCode.UpArrow)&&  Mathf.Abs(rigid2D.velocity.y)<1e-4f
            && (Step)GameController.step >= Step.Jump )
        {
            TriggerChange(Trigger.Jump); 
            rigid2D.AddForce(transform.up * jumpForce);
            TriggerChange(Trigger.Idle);
        }

        if(rigid2D.velocity.y<-0.1) 
            TriggerChange(Trigger.Fall);
        if (trigger == "Fall" && Mathf.Abs(rigid2D.velocity.y) < 1e-4f)
            TriggerChange(Trigger.Idle);
		#endregion
		#region 左右控制
        if (Input.GetKey(KeyCode.LeftArrow) && (Step)GameController.step >= Step.Run&&events==0)
        {
            LR = -1;
            if (trigger == "Idle") TriggerChange(Trigger.Run);
            if (speed < maxSpeed)
                rigid2D.AddForce(transform.right * walkForce * LR);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            TriggerChange(Trigger.Idle);
        
        if (Input.GetKey(KeyCode.RightArrow) && (Step)GameController.step >= Step.Run && events == 0)
        {
            LR = 1;
            if (trigger == "Idle") TriggerChange(Trigger.Run);
            if (speed < maxSpeed)
                rigid2D.AddForce(transform.right * walkForce * LR);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
             TriggerChange(Trigger.Idle);
		#endregion
        if (Conversation.Talk[GameController.clickNumber].Say == "crystal") LR = -1;//小精靈出現轉身
        if (LR!=0)//轉身
            transform.localScale = new Vector3(LR,1,1);        
    }
    void OnTriggerEnter2D (Collider2D other)//指定區域
    {
        if (other.gameObject.tag == "jump" && Conversation.Talk[GameController.clickNumber].Say == "walk")
            events = 1;
        if (other.gameObject.tag == "land" && Conversation.Talk[GameController.clickNumber].Say == "jump")
            events = 2;
    }
}
enum Trigger// 動畫切換
{
    Idle,Run,Hurt,Attcak,Jump,Fall
}
