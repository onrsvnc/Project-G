using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSFX : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;

    void Start() 
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        PlayRandom();
    }
    void PlayRandom()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }

}
