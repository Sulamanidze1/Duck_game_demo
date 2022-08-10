using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{  
    public AudioClip[] sounds;
    AudioSource audioSource;

    void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }

     public void PlaySound(int soundeffectID)
    {
        audioSource.PlayOneShot(sounds[soundeffectID]);
    }
}
