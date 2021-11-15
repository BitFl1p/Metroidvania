using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    public int side;
    private void Update()
    {
        transform.localPosition = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground" && GetComponentInParent<PlayerMovement>().onWall == false)
        {
            transform.parent.position += GetComponentInParent<PlayerMovement>().lastMove < 0 ? (Vector3)Vector2.left * 0.4f : (Vector3)Vector2.right * 0.4f;
            GetComponentInParent<PlayerMovement>().onWall = true;
            GetComponentInParent<PlayerMovement>().airDashed = false;
            GetComponentInParent<PlayerMovement>().registerMove = false;
            GetComponentInParent<PlayerMovement>().lastMove = transform.parent.eulerAngles.y > 0 ? side : -side;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" && Input.GetAxisRaw("Horizontal") != -GetComponentInParent<PlayerMovement>().lastMove && !Input.GetKey(KeyCode.Space))
        {
            GetComponentInParent<PlayerMovement>().registerMove = true;
            GetComponentInParent<PlayerMovement>().onWall = false;
        }
    }
}
