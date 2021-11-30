using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VladsUsefulScripts;

public class Enemy : MonoBehaviour
{
    internal Rigidbody2D rb;
    [SerializeField]
    public float drag;
    virtual internal void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    virtual internal void FixedUpdate()
    {
        rb.velocity = Clampers.Drag(rb.velocity, drag);
    }
}
