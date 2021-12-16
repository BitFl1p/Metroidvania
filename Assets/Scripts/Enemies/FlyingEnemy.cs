using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using VladsUsefulScripts;
[RequireComponent(typeof(Seeker)), RequireComponent(typeof(Rigidbody2D))]
public class FlyingEnemy : Enemy
{
    internal Transform target;
    internal float lastMove = 1;
    public float speed;
    public float maxSpeedMult;
    public float nextWaypointDistance = 3f;
    internal Path path;

    internal int currentWaypoint = 0;
    internal bool reachedEndOfPath, playerSeen;

    internal Seeker seeker;

    internal override void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0, 0.5f);
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    void UpdatePath()
    {
        if (seeker.IsDone() && target) seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        { 
            playerSeen = true;
            target = collision.transform;
        }
    }
    internal override void FixedUpdate()
    {
        if (playerSeen) FollowPlayer();
        if (rb.velocity.x != 0) lastMove = rb.velocity.x;
        if (lastMove < 0) transform.eulerAngles = new Vector2(0, 180);
        else transform.eulerAngles = new Vector2(0, 0);
    }
    internal virtual void FollowPlayer()
    {
        //base.FixedUpdate();
        if (path == null) return;
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else reachedEndOfPath = false;
        Vector2 force;
        if (reachedEndOfPath) force = ((Vector2)target.position - rb.position).normalized * speed;
        else force = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized * speed;

        rb.velocity = Clampers.ClampedDrag(rb.velocity + force, drag, -speed * maxSpeedMult, speed * maxSpeedMult);

        if (Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance) currentWaypoint++;
        
    }
}
