using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
