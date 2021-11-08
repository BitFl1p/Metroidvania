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
    public bool isGrounded;
    bool pressed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        
        rb.velocity = Clampers.VelCalc(Clampers.Drag(rb.velocity, drag), speed, maxSpeedMult);
        
        if(rb.velocity.x != 0) lastMove = rb.velocity.x;
        if (lastMove < 0) transform.eulerAngles = new Vector2(0,180);
        else transform.eulerAngles = new Vector2(0,0);

        if (Mathf.Abs(rb.velocity.x / (speed * maxSpeedMult)) < 0.1) anim.SetFloat("X", 0);
        else if (Mathf.Abs(rb.velocity.x / (speed * maxSpeedMult)) < 0.25) anim.SetFloat("X", 0.5f);
        else anim.SetFloat("X", 1); 
        if (rb.velocity.normalized.y < -0.5) anim.SetFloat("Y", 0);
        else if (rb.velocity.normalized.y < 0.5) anim.SetFloat("Y", 0.5f);
        else anim.SetFloat("X", 1);
        anim.SetBool("Grounded", isGrounded); 
        //anim.SetFloat("X", Mathf.Abs(rb.velocity.x / (speed * maxSpeedMult))); 
        anim.SetFloat("Y", rb.velocity.normalized.y);
    }
}
