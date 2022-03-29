using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectableObject : MonoBehaviour
{
    public static event Action<Transform, Transform> OnDetected = delegate { };

    [SerializeField] float detectionThreshold = 10f;
    [SerializeField] float detectionMultiplier = 1f;


    float currentDetection;
    bool isInSight = false;
    bool isDetectionStarted = false;
    bool isDetected = false;

    void OnEnable()
    {
        Earless.OnEnemyDetectStarted += CheckDetection;
    }

    void OnDisable()
    {
        Earless.OnEnemyDetectStarted -= CheckDetection;
    }

    IEnumerator StartDetecting(Transform detector)
    {
        while (isDetectionStarted)
        {
            yield return new WaitForSeconds(1f);

            if(isInSight && (currentDetection < detectionThreshold))
                currentDetection += detectionMultiplier;
            else if(!isInSight)
                currentDetection -= detectionMultiplier;
            
            isInSight = false;

            if (currentDetection >= detectionThreshold)
            {
                Debug.Log("ondetected");
                isDetected = true;
                OnDetected(transform, detector);
            }
            else if(currentDetection <= 0)
            {
                isDetectionStarted = false;
                isDetected = false;
                break;
            }
        }
    }

    void CheckDetection(Transform detector, Transform spotted)
    {
        if (spotted != transform)
            return;
        
        isInSight = true;

        if (!isDetectionStarted)
        {
            isDetectionStarted = true;
            StartCoroutine(StartDetecting(detector));
        }
    }

}
