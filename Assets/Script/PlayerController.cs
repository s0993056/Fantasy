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
    private PhysicsMaterial2D ground;//摩擦力5
    [SerializeField]
    private PhysicsMaterial2D air;//摩擦力0
    [SerializeField]
    private float jumpForce = 1400f;
    [SerializeField]
    private float maxSpeed = 12f;
    private float walkForce = 80f;//起步速度
    static string trigger = "Idle";
    AnimatorStateInfo stateinfo;
    public static int events = 0;
    int LR = 0;//左右翻轉
    #endregion
    void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        AnimatorStateInfo stateinfo = animator.GetCurrentAnimatorStateInfo(0);
    }
    void TriggerChange(Trigger t)// 動畫切換
    {
        //if ((Trigger)Enum.Parse(typeof(Trigger), trigger) < t||!Input.anyKeyDown)
        {
            //print($"{trigger} {(int)(Trigger)Enum.Parse(typeof(Trigger), trigger)} {t}");
            animator.ResetTrigger(trigger);
            trigger = t.ToString();
            animator.SetTrigger(trigger);
        }
    }
    void FixedUpdate()
    {
        #region 左右控制
        float speed = Mathf.Abs(rigid2D.velocity.x);
        if (speed < maxSpeed && trigger == "Run")
            rigid2D.AddForce(transform.right * walkForce * LR);
        #endregion
        #region 跳躍不卡牆
        //if (Mathf.Abs(rigid2D.velocity.y) > 1e-4f)rigid2D.AddForce(transform.right * rigid2D.velocity.x * -15);
        #endregion
        #region 跳，落控制
        if (trigger == "Jump")
        rigid2D.AddForce(transform.up * jumpForce);
        #endregion
    }
    void Update()
    {
        if (!Input.anyKeyDown && !stateinfo.IsName("jump")) TriggerChange(Trigger.Idle);
        #region 左右控制
        if (Input.GetKey(KeyCode.LeftArrow) && (Step)GameController.step >= Step.Run && events == 0)
        {
            LR = -1;
            if (trigger == "Idle") TriggerChange(Trigger.Run);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            TriggerChange(Trigger.Idle);

        if (Input.GetKey(KeyCode.RightArrow) && (Step)GameController.step >= Step.Run && events == 0)
        {
            LR = 1;
            if (trigger == "Idle") TriggerChange(Trigger.Run);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
            TriggerChange(Trigger.Idle);
        #endregion
        #region 跳躍不卡牆
        RaycastHit2D info = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y - 1.5501f), -Vector2.up, 0.3f);
        if (info.collider == null) { rigid2D.sharedMaterial = air; }
        else rigid2D.sharedMaterial = ground;
        #endregion
        #region 跳，落控制
        if (Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(rigid2D.velocity.y) < 1e-4f
            && (Step)GameController.step >= Step.Jump)
            TriggerChange(Trigger.Jump);
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
