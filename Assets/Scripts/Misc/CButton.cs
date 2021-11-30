using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CButton : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer sprite;
    #region Singleton Shit
    public static CButton instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    #endregion
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }
}
