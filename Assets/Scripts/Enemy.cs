using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VladsUsefulScripts;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float drag;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = Clampers.Drag(rb.velocity, drag);
    }
}
