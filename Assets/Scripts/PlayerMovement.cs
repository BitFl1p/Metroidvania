using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VladsUsefulScripts;
[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Collider2D)), RequireComponent(typeof(GroundCheck))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float speed, maxSpeedMult, jumpPow, drag;
    float lastMove;
    public bool isGrounded, registerMove;
    bool pressed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
             
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGrounded && Input.GetKey(KeyCode.Space) && !pressed)
        {
            pressed = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpPow);
        }
        if (!Input.GetKey(KeyCode.Space)) pressed = false;
        
        if(registerMove) rb.velocity = Clampers.VelCalc(Clampers.Drag(rb.velocity, drag), speed, maxSpeedMult);
        
        if(rb.velocity.x != 0 && registerMove) lastMove = rb.velocity.x;
        if (!registerMove) 
        {
            rb.velocity = Clampers.Drag(rb.velocity, drag);
            if (rb.velocity.x < drag && rb.velocity.x > -drag) registerMove = true;
        }
        if (lastMove < 0) transform.eulerAngles = new Vector2(0,180);
        else transform.eulerAngles = new Vector2(0,0);



        //---------- Animation -------------

        if (Mathf.Abs(rb.velocity.x / (speed * maxSpeedMult)) < 0.1) anim.SetFloat("X", 0);
        else if (Mathf.Abs(rb.velocity.x) < speed * maxSpeedMult + 1) anim.SetFloat("X", 0.5f);
        else anim.SetFloat("X", 1); 
        if (rb.velocity.y < -10) anim.SetFloat("Y", -1);
        else if (rb.velocity.y < 10) 
            anim.SetFloat("Y", 0f);
        else anim.SetFloat("Y", 1);
        anim.SetBool("Grounded", isGrounded); 
        //anim.SetFloat("X", Mathf.Abs(rb.velocity.x / (speed * maxSpeedMult))); 
        anim.SetFloat("Y", rb.velocity.normalized.y);
    }
}
