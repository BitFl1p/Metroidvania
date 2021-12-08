using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPlatforms : MonoBehaviour
{
    public List<GameObject> platforms;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            foreach (GameObject platform in platforms) platform.SetActive(!PlayerMovement.instance.canDash);
        }
    }
}
