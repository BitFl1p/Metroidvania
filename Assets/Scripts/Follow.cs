using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class Follow : MonoBehaviour
{
    public Transform target;
    public Vector2 offset;

    private void Update()
    {
        if (!target) Destroy(gameObject);
        transform.position = target.position + (Vector3)offset;
    }
}
