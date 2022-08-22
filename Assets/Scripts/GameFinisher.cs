using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameFinisher : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public void ScoreScreen()
    {
        if(playableDirector.state == PlayState.Paused)
        {
            SceneManager.LoadScene("Score Screen");
        }
    }
    void Update()
    {
        ScoreScreen();    
    }

}
