using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{

    [SerializeField] ObjectiveController objective;
    [SerializeField] LevelCompletedController levelCompletedController;
    [SerializeField] TextMeshProUGUI levelWinText;
    [SerializeField] TextMeshProUGUI levelWinEarningsText;
    [TextArea]
    [SerializeField] string levelWinEarnings;

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

            levelWinText.SetText(gameObject.name + " Completed");
            levelWinEarningsText.SetText(levelWinEarnings);
            StartCoroutine(levelCompletedController.ShowUI());
        }
    }
}
