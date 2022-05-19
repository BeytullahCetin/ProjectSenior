using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] ObjectiveController objective;

    bool isObjectiveTaken = false;

    private void OnEnable()
    {
        objective.OnObjectiveTaken += TakeObjective;
    }
    private void OnDisable()
    {
        objective.OnObjectiveTaken += TakeObjective;
    }

    private void TakeObjective()
    {
        isObjectiveTaken = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isObjectiveTaken)
            {
                Debug.Log("Objective not taken");
                return;
            }

            //Show Win Screen
            Debug.Log("Objective taken:" + objective.name);
        }
    }
}
