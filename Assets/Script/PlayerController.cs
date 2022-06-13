using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    [SerializeField]
    private PhysicsMaterial2D ground;
    [SerializeField]
    private PhysicsMaterial2D air;
    [SerializeField]
    private float jumpForce = 1400f;
    private float walkForce = 30f;//�_�B�t��
    [SerializeField]
    private float maxSpeed = 6f;
    static string trigger = "Idle";
    /*float x=0;
    float y=0;*/
    void Awake()
    {
        rigid2D=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }
    void TriggerChange(Trigger t)// �ʵe����
    {
        if ((Trigger)Enum.Parse(typeof(Trigger), trigger) < t||!Input.anyKeyDown)
        {
            animator.ResetTrigger(trigger);
            trigger = t.ToString();
            animator.SetTrigger(trigger);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Mathf.Abs(rigid2D.velocity.x);
        int LR = 0;//���k½��
		#region ���D���d��
		RaycastHit2D info = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y - 1.551f), -Vector2.up, 0.3f);
        if (info.collider == null) { rigid2D.sharedMaterial = air; }
        else { rigid2D.sharedMaterial = ground; }
        #endregion
        #region ���A������
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
		#region ���k����
        if (Input.GetKey(KeyCode.LeftArrow) && (Step)GameController.step >= Step.Run)
        {
            LR = -1;
            if (trigger == "Idle") TriggerChange(Trigger.Run);
            if (speed < maxSpeed)
                rigid2D.AddForce(transform.right * walkForce * LR);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && (Step)GameController.step >= Step.Run)
            TriggerChange(Trigger.Idle);
        
        if (Input.GetKey(KeyCode.RightArrow) && (Step)GameController.step >= Step.Run)
        {
            LR = 1;
            if (trigger == "Idle") TriggerChange(Trigger.Run);
            if (speed < maxSpeed)
                rigid2D.AddForce(transform.right * walkForce * LR);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && (Step)GameController.step >= Step.Run)
             TriggerChange(Trigger.Idle);
		#endregion
        if (GameController.clickNumber == 6) LR = -1;//6�p���F�X�{�ਭ
        if (LR!=0)//�ਭ
            transform.localScale = new Vector3(LR,1,1);        
    }
}
enum Trigger// �ʵe����
{
    Idle,Run,Hurt,Attcak,Jump,Fall
}
