using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Popup : MonoBehaviour
{
    TMP_Text text;
    Animator anim;
    #region Singleton Shit
    public static Popup instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion
    private void Start()
    {
        text = GetComponent<TMP_Text>();
        anim = GetComponent<Animator>();
    }
    public IEnumerator Pop(string message, float duration)
    {
        text.text = message;
        anim.SetBool("Popup", true);
        yield return new WaitForSeconds(duration);
        anim.SetBool("Popup", false);
    }
}
