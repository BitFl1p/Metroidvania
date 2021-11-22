using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool paused = false;
    public GameObject menu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                paused = false;
                Time.timeScale = 1;
                menu.SetActive(false);
            }
            else
            {
                paused = true;
                Time.timeScale = 0;
                menu.SetActive(true);
            }
        }
    }
    public void Resume()
    {
        paused = false;
        Time.timeScale = 1;
        menu.SetActive(false);
    }
}
