using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VladsUsefulScripts;
[ExecuteInEditMode]
public class EnemyPatroller : Enemy
{
    public List<Vector2> patrol = new List<Vector2>(2) { };
    public float waypointDistance = 3, speed;
    public int index;
    public float knockTimer = 0;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < patrol.Count - 1; i++) Gizmos.DrawLine(patrol[i], patrol[i + 1]);
        foreach (Vector2 location in patrol) Gizmos.DrawSphere(location, .1f);
    }
    internal override void FixedUpdate()
    {
        if (knockTimer > 0) 
        {
            base.FixedUpdate();
            knockTimer -= Time.deltaTime; 
        }
        else if (Vector2.Distance(patrol[index], transform.position) > waypointDistance)
        {
            rb.velocity = (patrol[index] - rb.position).normalized * speed;
        }
        else
        {
            if (index + 1 >= patrol.Count) index = 0;
            else index++;
        }
    }
}
