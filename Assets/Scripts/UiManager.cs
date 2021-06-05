using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{


    



    // Start is called before the first frame update
    void Start()
    {

     



    }

    // Update is called once per frame
    void Update()
    {

    }

   

    public void Restrar()
    {
        ScoreScript.score = 0;
        SceneManager.LoadScene(1);
    }
    public void MENU()
    {
        ScoreScript.score = 0;
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        
    }
    public void NewGame()
    {
        SceneManager.LoadScene(3);

    }
    public void START()
    {
        SceneManager.LoadScene(1);
        
    }
    
    public void Exit()
    {
        Application.Quit();
    }


}
