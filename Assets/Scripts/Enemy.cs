using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVfx;
    [SerializeField] int scoreGained;
    [SerializeField] int health;
    GameObject SpawnAtRuntime;
    ScoreBoard scoreBoard;
    
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        SpawnAtRuntime = GameObject.FindWithTag("Spawn at Runtime");
       // gameObject.AddComponent<Rigidbody>().useGravity = false; 
       // with "add component" we add rigid body for some enemy models that only has colliders in their children so our shots would work but its not needed here
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHitVFX();
        ProcessHealth();
    }

    void ProcessHitVFX()
    {
        GameObject hitVfxIns = Instantiate(hitVfx, transform.position, Quaternion.identity);
        hitVfxIns.transform.parent = SpawnAtRuntime.transform;
    }
    void ProcessScore()
    {
        scoreBoard.ModifyScore(scoreGained);
    }

    void ProcessHealth()
    {
        if (health >= Mathf.Epsilon)
        {
            health --; // Consider that we have dual lasers so we will be doing double damage
        }
        else if (health <= Mathf.Epsilon)
        {
            ProcessDeath();
        }
    }

    void ProcessDeath()
    {
        ProcessScore();
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = SpawnAtRuntime.transform;
        Destroy(gameObject);
    }

}
