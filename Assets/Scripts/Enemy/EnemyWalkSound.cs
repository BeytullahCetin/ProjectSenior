using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkSound : MonoBehaviour
{
    [SerializeField] AudioClip[] steps;
    [SerializeField] AudioSource stepAudioSource;

    void Step()
    {
        AudioClip clip = GetRandomStepClip();
        stepAudioSource.PlayOneShot(clip);
    }

    AudioClip GetRandomStepClip()
    {
        int randomNumber = Random.Range(0, steps.Length);
        return steps[randomNumber];
    }
}
