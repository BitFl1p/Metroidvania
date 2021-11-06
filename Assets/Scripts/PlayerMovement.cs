using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VladsUsefulScripts;
[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Collider2D)), RequireComponent(typeof(GroundCheck))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed, maxSpeedMult, jumpPow, drag;
    public bool isGrounded;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * jumpPow;
        }
        rb.velocity = Clampers.VelCalc(Clampers.Drag(rb.velocity, drag), speed, maxSpeedMult);
    }
}
