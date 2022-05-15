using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Detectable : MonoBehaviour
{
    //public enum DetectionType { Discrete, Continuous };

    [SerializeField]float currentDetection = 0f;
    [SerializeField] float maxDetection = 10f;
    [SerializeField] float detectionIncreaseRate = 1f;
    [SerializeField] float detectionDecreseRate = 1f;
    [SerializeField] bool isContinouslyDetectable = false;
    bool isDetected = false;
    bool isDetectionStarted = false;

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            currentDetection = 0;
    }

    public void DetectionHit(Enemy enemy)
    {
        if (currentDetection < maxDetection)
            currentDetection += detectionIncreaseRate;

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
        int i = 0;
        while (isDetected)
        {
            detectorEnemy.Detect(this);
            Debug.Log("Detect Continously" + i++);
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator DetectionCountDown(Enemy detectorEnemy)
    {
        while (currentDetection > 0)
        {
            isDetected = currentDetection >= maxDetection;
            currentDetection-= detectionDecreseRate;
            yield return new WaitForSeconds(1);
        }

        isDetected = false;
        isDetectionStarted = false;
        detectorEnemy.EndDetect(this);
    }
}
