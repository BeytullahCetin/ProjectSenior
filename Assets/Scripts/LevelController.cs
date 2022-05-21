using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{

    [SerializeField] ObjectiveController[] objectives;
    Dictionary<ObjectiveController, bool> isObjectiveTakenControl = new Dictionary<ObjectiveController, bool>();

    [SerializeField] LevelCompletedController levelCompletedController;
    [SerializeField] TextMeshProUGUI levelWinText;
    [SerializeField] TextMeshProUGUI levelWinEarningsText;

    [TextArea]
    [SerializeField] string levelWinEarnings;
    [SerializeField] ThrowableType[] LevelEarnings;

    PlayerInventory playerInventory;

    bool isLevelCompleted = false;

    private void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        objectives = GetComponentsInChildren<ObjectiveController>();
        for (int i = 0; i < objectives.Length; i++)
        {
            isObjectiveTakenControl.Add(objectives[i], false);
        }

    }

    private void OnEnable()
    {
        foreach (ObjectiveController objective in objectives)
        {
            objective.OnObjectiveTaken += TakeObjective;
        }
    }
    private void OnDisable()
    {
        foreach (ObjectiveController objective in objectives)
        {
            objective.OnObjectiveTaken -= TakeObjective;
        }
    }

    private void TakeObjective(ObjectiveController objective)
    {
        Debug.Log(isObjectiveTakenControl);
        if (isObjectiveTakenControl.ContainsKey(objective))
        {
            isObjectiveTakenControl[objective] = true;
        }
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
            foreach (bool control in isObjectiveTakenControl.Values)
            {
                if (control == false)
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
