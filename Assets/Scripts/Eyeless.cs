using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyeless : MonoBehaviour
{
    [SerializeField] float stopDistance = 5f;

    Transform lastHearedSound;
    Vector3 targetDistanceVector;

    private void OnEnable()
    {
        HearableObject.OnHearableObjectMakeNoise += HearSounds;
    }

    private void OnDisable()
    {
        HearableObject.OnHearableObjectMakeNoise -= HearSounds;

    }

    private void HearSounds(Transform obj)
    {
        lastHearedSound = obj;
        Debug.Log("Hear something. At pos: " + lastHearedSound.position);

        StartCoroutine(GoToSound(obj));
    }

    IEnumerator GoToSound(Transform target)
    {
        targetDistanceVector = target.position - transform.position;
        while (targetDistanceVector.magnitude > stopDistance)
        {
            transform.position += targetDistanceVector.normalized;
            targetDistanceVector = target.position - transform.position;
            yield return null;
        }
    }
}
