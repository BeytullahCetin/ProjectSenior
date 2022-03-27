using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearableObject : MonoBehaviour
{
    public static event Action<Transform> OnSound = delegate { };

    private void OnCollisionEnter(Collision other)
    {
        OnSound(transform);
    }
}
