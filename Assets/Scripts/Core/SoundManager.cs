using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        if (instance != this && instance != null)
        {
            Destroy(gameObject);
        }

    }

    public void PlaySound(AudioClip _source)
    {
        source.PlayOneShot(_source);
    }
}
