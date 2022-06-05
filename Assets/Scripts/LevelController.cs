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
    DoorLighting doorLighting;

    bool isLevelCompleted = false;

    public bool IsLevelCompleted { get { return isLevelCompleted; } }

    private void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        doorLighting = GetComponentInChildren<DoorLighting>();

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
        // When Player exits from a level
        if (other.gameObject.CompareTag("Player"))
        {
            //Main ambience starts to play
            SoundManager.Instance.PlayMainAmbience();

            //Check if all objectives taken
            foreach (bool control in isObjectiveTakenControl.Values)
            {
                if (control == false)
                    return;
            }

            //If all objectives taken then
            //Check if level completed previously
            if (isLevelCompleted)
                return;
            
            //If not then level compeltion process starts
            levelWinText.SetText(gameObject.name + " Completed");
            levelWinEarningsText.SetText(levelWinEarnings);
            StartCoroutine(levelCompletedController.ShowUI());
            AddLevelEarnings(LevelEarnings);
            doorLighting.ChangeMaterial(1);
            isLevelCompleted = true;

            //And check if all levels are completed to end the game
            GameCompletedController.Instance.CheckGameCompleted();
        }
    }
}
