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
        if (target == null) Destroy(gameObject);
        transform.position = target.transform.position + (Vector3)offset;
    }
}
