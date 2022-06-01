using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] float fadeTime = .5f;
    bool isPlayingMainAmbience = true;

    [SerializeField] AudioSource mainAmbienceAudioSource;
    [SerializeField] AudioSource externalAmbienceAudioSource;

    [SerializeField] AudioSource oneShotAudioSource;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;

        PlayMainAmbience();
    }

    public void PlayClip(AudioClip clip)
    {
        oneShotAudioSource.PlayOneShot(clip);
    }

    public void PlayMainAmbience()
    {
        StopAllCoroutines();
        StartCoroutine(PlayMainAmbienceRoutine());
        isPlayingMainAmbience = true;
    }

    IEnumerator PlayMainAmbienceRoutine()
    {
        mainAmbienceAudioSource.Play();
        float timeElapsed = 0;

        while (timeElapsed < fadeTime)
        {
            mainAmbienceAudioSource.volume = Mathf.Lerp(0, 1, timeElapsed / fadeTime);
            externalAmbienceAudioSource.volume = Mathf.Lerp(1, 0, timeElapsed / fadeTime);
            timeElapsed += Time.deltaTime;
        }

        externalAmbienceAudioSource.Stop();
        yield return null;
    }

    public void SwapAmbience(AudioClip clip)
    {
        StopAllCoroutines();
        StartCoroutine(FadeTrack(clip));
        isPlayingMainAmbience = false;
    }

    IEnumerator FadeTrack(AudioClip clipToFadeIn)
    {
        float timeElapsed = 0;
        Debug.Log("coroutine started");
        if (true == isPlayingMainAmbience)
        {
            Debug.Log("coroutine if");
            externalAmbienceAudioSource.clip = clipToFadeIn;
            externalAmbienceAudioSource.Play();

            while (timeElapsed < fadeTime)
            {
                externalAmbienceAudioSource.volume = Mathf.Lerp(0, 1, timeElapsed / fadeTime);
                mainAmbienceAudioSource.volume = Mathf.Lerp(1, 0, timeElapsed / fadeTime);
                timeElapsed += Time.deltaTime;

            }
            mainAmbienceAudioSource.Stop();
            yield return null;
        }
    }

    public void StopAllSounds()
    {
        mainAmbienceAudioSource.Stop();
        externalAmbienceAudioSource.Stop();
        oneShotAudioSource.Stop();
    }


}
