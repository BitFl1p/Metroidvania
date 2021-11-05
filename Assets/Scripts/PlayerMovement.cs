using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VladsUsefulScripts;
[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed, maxSpeedMult;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Clampers.VelCalc(rb.velocity, speed, maxSpeedMult);
    }
}
