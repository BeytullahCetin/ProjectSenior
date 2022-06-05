using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLureController : LureController
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Light audioLight;
    [SerializeField] Transform audioLightTransform;
    [SerializeField] int SoundLureDuration = 15;

    float duration = 0;

    public override void Interaction()
    {
        if (canInteractable && !isUsed)
            StartCoroutine(StartAlarm());

    }

    IEnumerator StartAlarm()
    {
        // Alarm sound will be played for given duration, and
        //alarm light will be started to rotate

        isUsed = true;
        audioLight.enabled = true;
        audioSource.Play();
        ActivateLure();

        while (duration < SoundLureDuration)
        {
            audioLightTransform.Rotate(Vector3.right);
            duration += Time.deltaTime;
            yield return null;
        }

        duration = 0;
        audioSource.Stop();
    }

}
