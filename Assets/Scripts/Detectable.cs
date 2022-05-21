using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Detectable : MonoBehaviour
{
    //public enum DetectionType { Discrete, Continuous };

    float currentDetection = 0f;
    float maxDetection = 10f;
    [Range(1, 5)]
    [SerializeField] float detectionIncreaseRate = 1f;
    [Range(1, 5)]
    [SerializeField] float detectionDecreseRate = 1f;
    [SerializeField] bool isContinouslyDetectable = false;

    PlayerMovement playerMovement;

    bool isDetected = false;
    bool isDetectionStarted = false;


    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            currentDetection = 0;
    }

    public void DetectionHit(Enemy enemy)
    {
        if (enemy.GetComponent<Listener>())
        {
            if (!playerMovement.IsMoving)
                return;

            if (playerMovement.IsMoving && !playerMovement.IsRunning)
                return;
        }

        if (currentDetection < maxDetection)
        {
            currentDetection += detectionIncreaseRate;

        }

        if (!isDetectionStarted)
        {
            isDetectionStarted = true;
            StartCoroutine(DetectionCountDown(enemy));
        }

        if (isDetected)
        {
            switch (isContinouslyDetectable)
            {
                case true:
                    StartCoroutine(DetectContinously(enemy));
                    break;
                case false:
                    enemy.Detect(this);
                    break;
            }
        }
    }

    IEnumerator DetectContinously(Enemy detectorEnemy)
    {
        while (isDetected)
        {
            detectorEnemy.Detect(this);
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator DetectionCountDown(Enemy detectorEnemy)
    {
        while (currentDetection > 0)
        {
            isDetected = currentDetection >= maxDetection;
            currentDetection -= detectionDecreseRate;
            yield return new WaitForSeconds(1);
        }

        isDetected = false;
        isDetectionStarted = false;
        detectorEnemy.EndDetect(this);
    }
}
