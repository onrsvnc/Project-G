using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float reloadLevelDelay = 1f;
    [SerializeField] ParticleSystem deathExplosion;
    [SerializeField] ParticleSystem laserR;
    [SerializeField] ParticleSystem laserL;


    // void OnCollisionEnter(Collision other) 
    // {
    //     switch (other.gameObject.tag)   //Switch method for debugging
    //     {
    //         case "Enemy":
    //         Debug.Log("Collided with Enemy");
    //         break;

    //         case "Pipe":
    //         Debug.Log("Collided with Pipe");
    //         break;
            
    //         case "Environment":
    //         Debug.Log("Collided with Environment");
    //         break;
    //     }
    // } 
    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Triggered!! by " + other.gameObject.name);
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        deathExplosion.Play();
        DisableLasers();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
        GetComponentInParent<PlayerController>().enabled = false;
        Invoke("ReloadLevel", reloadLevelDelay);
    }

    void DisableLasers()
    {
        var emmisionR = laserR.emission;
        var emmisionL = laserL.emission;
        emmisionR.enabled = false;
        emmisionL.enabled = false;
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    

    
}
