using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class Spike : MonoBehaviour
{
    float count = 0.5f;
    public Vector2 respawnLocation;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(respawnLocation, .2f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(respawnLocation, .1f);
    }
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerMovement.instance.GetComponent<PlayerHealth>().Damage(1, GetComponent<Collider2D>(), 0);
            PlayerMovement.instance.transform.position = respawnLocation;
        }
    }
}
