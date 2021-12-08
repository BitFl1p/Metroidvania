using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompy : MonoBehaviour
{
    public float timeStomping, timeWaiting, speed, side, height;
    float stompCounter, waitCounter;
    public bool stomping, allowedToStomp;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stompCounter = timeStomping;
        waitCounter = timeWaiting;
    }
    private void Update()
    {
        if (!allowedToStomp) 
        {
            if (transform.localPosition.y > height) rb.velocity = new Vector2(0, 0);
            else rb.velocity += new Vector2(side, 1) * speed;
            return; 
        }
        if (stomping)
        {
            stompCounter -= Time.deltaTime;
            if(stompCounter > 0)
            {
                rb.velocity += new Vector2(side, -1) * speed;
            }
            else
            {
                stomping = false;
                stompCounter = timeStomping;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            if (waitCounter > 0)
            {
                if (transform.localPosition.y > height) rb.velocity = new Vector2(0, 0) * speed;
                else rb.velocity += new Vector2(side, 1) * speed;
            }
            else
            {
                stomping = true;
                waitCounter = timeWaiting;
            }
        }
    }
}
