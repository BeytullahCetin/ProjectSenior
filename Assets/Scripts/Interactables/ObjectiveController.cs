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
            // If an objective taken enemies will be alerted,
            //OnObjectiveTaken event triggered,
            //a sound clip played and
            //Objective will be destroyed.
            ActivateLure();
            OnObjectiveTaken(this);
            SoundManager.Instance.PlayClip(objectiveAudioClip);
            Destroy(gameObject);
        }
    }
}
