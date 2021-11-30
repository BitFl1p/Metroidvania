using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class Follow : MonoBehaviour
{
    public GameObject target;
    public Vector2 offset;

    private void Update()
    {
        if (!target) 
        { 
            Destroy(gameObject);
            return;
        }
        transform.position = (Vector2)target.transform.position + offset;
    }
}
