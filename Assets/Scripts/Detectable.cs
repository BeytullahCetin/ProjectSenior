using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Detectable : MonoBehaviour
{
    //public enum DetectionType { Discrete, Continuous };

    public static event Action<Transform> OnDetected = delegate { };
    public static event Action<Transform> OnDetectionEnds = delegate { };


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

    public void DetectionHit()
    {
        if (currentDetection < maxDetection)
            currentDetection += detectionIncreaseRate;

        if (!isDetectionStarted)
        {
            isDetectionStarted = true;
            StartCoroutine(DetectionCountDown());
        }

        if (isDetected)
        {
            switch (isContinouslyDetectable)
            {
                case true:
                    StartCoroutine(DetectContinously());
                    break;
                case false:
                    OnDetected(this.transform);
                    break;
            }
        }
    }

    IEnumerator DetectContinously()
    {
        int i = 0;
        while (isDetected)
        {
            OnDetected(this.transform);
            Debug.Log("Detect Continously" + i++);
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator DetectionCountDown()
    {
        while (currentDetection > 0)
        {
            isDetected = currentDetection >= maxDetection;
            currentDetection-= detectionDecreseRate;
            yield return new WaitForSeconds(1);
        }

        isDetected = false;
        isDetectionStarted = false;
        OnDetectionEnds(this.transform);
    }
}
