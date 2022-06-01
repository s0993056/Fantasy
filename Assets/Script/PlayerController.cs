using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    public float jumpForce = 1200f;
    public float walkForce = 20f;
    public float maxSpeed = 6f;
    static string trigger = "Idle Trigger";
    void Start()
    {
        rigid2D=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }
    void TriggerChange(string t)
    {
        animator.ResetTrigger(trigger);
        trigger = t;
        animator.SetTrigger(trigger);
    }

    // Update is called once per frame
    void Update()
    {
        /*this.transform.position = new Vector3
            (Mathf.Clamp(this.transform.position.x, -2.4f, 2.4f),
            this.transform.position.y, this.transform.position.z);*/
        float speed = Mathf.Abs(rigid2D.velocity.x);
        int key = 0;
        if (Input.GetKeyDown(KeyCode.UpArrow)&& rigid2D.velocity.y< Mathf.Abs(.0001f))
        {
            //TriggerChange("Jump Trigger"); 
            rigid2D.AddForce(transform.up * jumpForce);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TriggerChange("Walk Trigger");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
            //rigid2D.velocity = Vector2.left * 6;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            TriggerChange("Idle Trigger");
            //rigid2D.velocity = Vector2.left*2;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            TriggerChange("Walk Trigger");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {    TriggerChange("Idle Trigger");
            //rigid2D.AddForce(Vector2.left * walkForce*10);
        }
        if (speed < maxSpeed)
            rigid2D.AddForce(transform.right * walkForce*key);

        if (key!=0)
            transform.localScale = new Vector3(key,1,1);
    }
}
enum InputKey
{
    LeftArrow,RightArrow
}
