using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    public PhysicsMaterial2D ground;
    public PhysicsMaterial2D air;
    public float jumpForce = 1400f;
    public float walkForce = 30f;
    public float maxSpeed = 6f;
    static string trigger = "Idle";
    /*float x=0;
    float y=0;*/
    void Start()
    {
        rigid2D=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }
    void TriggerChange(Trigger t)
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
        /*if (rigid2D.velocity.x>x) x = rigid2D.velocity.x;
        if (rigid2D.velocity.y > y) y = rigid2D.velocity.y;
        Debug.Log($"{x} {y}");*/
        float speed = Mathf.Abs(rigid2D.velocity.x);
        RaycastHit2D info = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y - 1.551f), -Vector2.up, 0.3f);
        if (info.collider == null) { rigid2D.sharedMaterial = air; }
        else { rigid2D.sharedMaterial = ground; }
        int key = 0;
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

        if (Input.GetKey(KeyCode.LeftArrow) && (Step)GameController.step >= Step.Run)
        {
            key = -1;
            if (trigger == "Idle") TriggerChange(Trigger.Run);
            if (speed < maxSpeed)
                rigid2D.AddForce(transform.right * walkForce * key);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && (Step)GameController.step >= Step.Run)
            TriggerChange(Trigger.Idle);

        if (Input.GetKey(KeyCode.RightArrow) && (Step)GameController.step >= Step.Run)
        {
            key = 1;
            if (trigger == "Idle") TriggerChange(Trigger.Run);
            if (speed < maxSpeed)
                rigid2D.AddForce(transform.right * walkForce * key);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && (Step)GameController.step >= Step.Run)
             TriggerChange(Trigger.Idle);
        

        if (key!=0)
            transform.localScale = new Vector3(key,1,1);
        
    }
}
enum Trigger
{
    Idle,Run,Hurt,Attcak,Jump,Fall
}
