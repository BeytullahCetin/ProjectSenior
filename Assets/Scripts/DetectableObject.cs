using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectableObject : MonoBehaviour
{
    public static event Action<Transform> OnDetected = delegate { };

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

    IEnumerator StartDetecting(Transform obj)
    {
        while (isDetectionStarted)
        {
            yield return new WaitForSeconds(1f);

            if(isInSight && (currentDetection < detectionThreshold))
                currentDetection += detectionMultiplier;
            else if(!isInSight)
                currentDetection -= detectionMultiplier;
            
            isInSight = false;
            Debug.Log("Detection Meter: " + currentDetection + "/" + detectionThreshold);

            if (currentDetection >= detectionThreshold)
            {
                isDetected = true;
            }
            else if(currentDetection <= 0)
            {
                isDetectionStarted = false;
                isDetected = false;
                break;
            }
        }
    }

    void CheckDetection(Transform obj)
    {
        if (obj != transform)
            return;
        
        isInSight = true;

        if (!isDetectionStarted)
        {
            isDetectionStarted = true;
            StartCoroutine(StartDetecting(obj));
        }
    }

}
