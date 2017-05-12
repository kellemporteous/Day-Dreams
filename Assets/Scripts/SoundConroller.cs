using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundConroller : MonoBehaviour {
    public static SoundConroller soundController = null;

    public AudioSource audioSource;

    void Awake()
    {
        if (soundController == null)
        {
            soundController = this;
        }
        else if (soundController != this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    
}
