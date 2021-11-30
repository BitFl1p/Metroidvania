using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private void Update() => transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
}
