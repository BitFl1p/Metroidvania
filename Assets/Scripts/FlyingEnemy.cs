using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using VladsUsefulScripts;
[RequireComponent(typeof(Seeker)), RequireComponent(typeof(Rigidbody2D))]
public class FlyingEnemy : Enemy
{
    public Transform target;

    public float speed;
    public float maxSpeedMult;
    public float nextWaypointDistance = 3f;
    Path path;

    int currentWaypoint = 0;
    bool reachedEndOfPath;

    Seeker seeker;

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
        if (seeker.IsDone()) seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    internal override void FixedUpdate()
    {
        //base.FixedUpdate();
        if (path == null) return;
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else reachedEndOfPath = false;
        Vector2 force = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized * speed;

        rb.velocity = Clampers.ClampedDrag(rb.velocity + force, drag, -speed * maxSpeedMult, speed * maxSpeedMult);

        if (Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance) currentWaypoint++;
        
    }
}
