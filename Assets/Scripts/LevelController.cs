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
    [SerializeField] ThrowableType[] LevelEarnings;

    PlayerInventory playerInventory;

    bool isObjectiveTaken = false;
    bool isLevelCompleted = false;

    private void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

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

    void AddLevelEarnings(ThrowableType[] objectsToAdd)
    {
        foreach (ThrowableType throwableType in objectsToAdd)
        {
            playerInventory.AddAmmo(throwableType.ToString());
        }
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

            if (isLevelCompleted)
                return;

            levelWinText.SetText(gameObject.name + " Completed");
            levelWinEarningsText.SetText(levelWinEarnings);
            StartCoroutine(levelCompletedController.ShowUI());
            AddLevelEarnings(LevelEarnings);
            isLevelCompleted = true;
        }
    }
}
