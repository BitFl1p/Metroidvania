using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour
{
    public TMP_Text textObject;
    float count;
    public float maxCount;
    public void SetText(string text)
    {
        textObject.text = text;
    }
    private void Start()
    {
        count = maxCount;
    }
    private void Update()
    {
        count -= Time.deltaTime;
        if (count > 0) transform.position += Vector3.up * 0.002f ;
        else Destroy(gameObject);
    }


}
