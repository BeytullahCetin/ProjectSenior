using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : LureController
{
    public event Action<ObjectiveController> OnObjectiveTaken = delegate { };
    [SerializeField] AudioClip objectiveAudioClip;

    public override void Interaction()
    {
        if (canInteractable)
        {
            ActivateLure();
            OnObjectiveTaken(this);
            Debug.Log("Objective Interaction");
            SoundManager.Instance.PlayClip(objectiveAudioClip);
            Destroy(gameObject);
        }
    }
}
