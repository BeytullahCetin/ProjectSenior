using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearableObject : MonoBehaviour
{
    public static event Action<Transform> OnHearableObjectMakeNoise = delegate { };

    private void OnCollisionEnter(Collision other)
    {
        OnHearableObjectMakeNoise(transform);
    }
}
