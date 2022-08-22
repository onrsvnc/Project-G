using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    static ScoreKeeper instance;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMenu();
        }
    }
    public void LoadGame()
    {
        if(instance != null)
        {
            scoreKeeper.ResetScore();
        }
        SceneManager.LoadScene("Main Level");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
