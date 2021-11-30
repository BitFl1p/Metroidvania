using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeGroundCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground") transform.parent.GetComponent<SlimeJumper>().isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground") transform.parent.GetComponent<SlimeJumper>().isGrounded = false;
    }
}
