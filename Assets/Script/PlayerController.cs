using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    public float jumpForce = 1200f;
    public float walkForce = 50f;
    public float maxSpeed = 6f;
    static string trigger = "Idle";
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
        /*this.transform.position = new Vector3
            (Mathf.Clamp(this.transform.position.x, -2.4f, 2.4f),
            this.transform.position.y, this.transform.position.z);*/
        float speed = Mathf.Abs(rigid2D.velocity.x);
        int key = 0;
        if (Input.GetKeyDown(KeyCode.UpArrow)&&  Mathf.Abs(rigid2D.velocity.y)<1e-4f)
        {
            TriggerChange(Trigger.Jump); 
            rigid2D.AddForce(transform.up * jumpForce);
            TriggerChange(Trigger.Idle);
        }

        if(rigid2D.velocity.y<-0.1) 
            TriggerChange(Trigger.Fall);

        if (trigger == "Fall" && Mathf.Abs(rigid2D.velocity.y) < 1e-4f)
        { 
            TriggerChange(Trigger.Idle); 
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
            if (trigger == "Idle") TriggerChange(Trigger.Run);
            if (speed < maxSpeed)
                rigid2D.AddForce(transform.right * walkForce * key);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            TriggerChange(Trigger.Idle);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
            if (trigger == "Idle") TriggerChange(Trigger.Run);
            if (speed < maxSpeed)
                rigid2D.AddForce(transform.right * walkForce * key);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {    TriggerChange(Trigger.Idle);
        }
        

        if (key!=0)
            transform.localScale = new Vector3(key,1,1);
        
    }
}
enum Trigger
{
    Idle,Run,Hurt,Attcak,Jump,Fall
}
