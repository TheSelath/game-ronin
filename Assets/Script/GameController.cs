using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    public GameObject gameOver;
   
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ShowGameOver();            
        }        
    }
    
    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }  

    public void StartGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {        
        UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();
    } 
    
}
