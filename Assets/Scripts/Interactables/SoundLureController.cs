using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLureController : LureController
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Light audioLight;
    [SerializeField] Transform audioLightTransform;

    public override void Interaction()
    {
        if (canInteractable && !isUsed)
        {
            audioLight.enabled = true;
            audioSource.Play();
            StartCoroutine(ChangeLightTransform());
        }
    }

    IEnumerator ChangeLightTransform()
    {
        while (true)
        {
            audioLightTransform.Rotate(Vector3.right);
            yield return null;
        }
    }

}
