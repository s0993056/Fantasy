using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    public float jumpForce = 200f;
    public float walkForce = 10f;
    public float maxSpeed = 2f;
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
        /*if (Input.GetKeyDown(KeyCode.Space)&& rigid2D.velocity.y==0)
        {
            animator.SetTrigger("Jump Trigger"); 
            rigid2D.AddForce(transform.up * jumpForce);
        }*/

        //animator.SetTrigger("Idle Trigger");

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TriggerChange("Walk Trigger");
            key = -1;
            rigid2D.AddForce(key * transform.right * walkForce);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            TriggerChange("Idle Trigger");

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            TriggerChange("Walk Trigger");
            key = 1;
            rigid2D.AddForce(key * transform.right * walkForce);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
            TriggerChange("Idle Trigger");

        //if (speed < maxSpeed)

        if (key!=0)
            transform.localScale = new Vector3(key,1,1);
        /*if (rigid2D.velocity.y == 0)
            animator.speed = speed / 2f;
        else animator.speed =0.55f;*/

        //if (transform.position.y < -10)SceneManager.LoadScene("GameScene");
    }
}
enum InputKey
{
    LeftArrow,RightArrow
}
