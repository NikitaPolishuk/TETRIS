using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    BlockLogic blockLogic;

    

    public void ButtonPause()
    {
        if (GameIsPaused)
        {
            Resum();
        }
        else
        {
            Pause();
        }
    }

    public void Resum()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = true;
        GameIsPaused = false;
        


    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
       
    }
}

