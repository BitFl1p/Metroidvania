using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VladsUsefulScripts;

public class SlimeJumper : EnemyPatroller
{
    ParticleSystem.EmissionModule em;
    Animator anim;
    public bool isGrounded;
    public float jumpTimerMax, jumpPower;
    float jumpTimer = 1, lastMove = 1;
    internal override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        em = GetComponentInChildren<ParticleSystem>().emission;
    }
    internal override void FixedUpdate()
    {
        if (isGrounded) lastMove = patrol[index].x - transform.position.x;
        if (lastMove < 0) transform.eulerAngles = new Vector2(0, 180);
        else transform.eulerAngles = new Vector2(0, 0);
        jumpTimer -= Time.deltaTime;
        if (knockTimer > 0)
        {
            knockTimer -= Time.deltaTime;
        }
        else if (Vector2.Distance(patrol[index], transform.position) > waypointDistance)
        {
            if (jumpTimer < 0)
            {
                rb.velocity = new Vector2((patrol[index] - rb.position).normalized.x * speed, 1 * jumpPower);
                jumpTimer = jumpTimerMax;
            }
        }
        else
        {
            if (index + 1 >= patrol.Count) index = 0;
            else index++;
        }
        if (jumpTimer > 1.8) em.rateOverTime = 30;
        else em.rateOverTime = 0;
        rb.velocity = Clampers.Drag(rb.velocity, drag);
        anim.SetBool("Grounded", isGrounded);
    }
}
