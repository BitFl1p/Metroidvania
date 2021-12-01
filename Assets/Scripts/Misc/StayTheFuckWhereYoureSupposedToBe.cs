using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayTheFuckWhereYoureSupposedToBe : MonoBehaviour
{
    public Vector2 offset = Vector2.zero;
    void Update() => transform.localPosition = offset;
}
