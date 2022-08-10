using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        Debug.Log(this.name + " Collided With " + other.gameObject.name);
        // switch (other.gameObject.tag)   //Switch method for debugging
        // {
        //     case "Enemy":
        //     Debug.Log("Collided with Enemy");
        //     break;

        //     case "Pipe":
        //     Debug.Log("Collided with Pipe");
        //     break;
            
        //     case "Environment":
        //     Debug.Log("Collided with Environment");
        //     break;
        // }
    } 
    void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Triggered!! by " + other.gameObject.name);
    } 

    
}
