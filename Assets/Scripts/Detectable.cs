using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Detectable : MonoBehaviour
{
    public static event Action<Transform> OnDetected = delegate { };
    public static event Action<Transform> OnDetectionEnds = delegate { };
    

    float currentDetection = 0f;
    [SerializeField] float maxDetection = 10f;
    [SerializeField] float detectionIncreaseRate = 1f;
    bool isDetected = false;
    bool isDetectionStarted = false;
    bool detectionEventThrower = false;

    private void Start()
    {

    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            currentDetection = 0;
    }

    public void DetectionHit()
    {
        if (currentDetection < maxDetection)
            currentDetection += detectionIncreaseRate;

        isDetected = currentDetection >= maxDetection;

        if (!isDetectionStarted)
        {
            isDetectionStarted = true;
            StartCoroutine(DetectionCountDown());
        }

        if (isDetected && !detectionEventThrower)
        {
            detectionEventThrower = true;
            OnDetected(this.transform);
        }
    }

    IEnumerator DetectionCountDown()
    {
        while (currentDetection > 0)
        {
            currentDetection--;
            yield return new WaitForSeconds(1);
        }

        isDetected = false;
        isDetectionStarted = false;
        detectionEventThrower = false;
        OnDetectionEnds(this.transform);

    }
}
