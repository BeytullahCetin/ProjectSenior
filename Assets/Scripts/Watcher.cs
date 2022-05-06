using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Detectable;

public class Watcher : Enemy
{
    [SerializeField] float detectDistance = 10f;
    [SerializeField] float detectionDifficulty = 5f;

    Transform detector;
    Transform hitTransform;
    RaycastHit hit;
    Detectable currentDetected;

    private void Start()
    {
        CreateDetector();
    }

    private void Update()
    {
        LookForDetectable();
    }

    void CreateDetector()
    {
        detector = new GameObject("Detector").transform;
        detector.parent = transform;
        detector.localPosition = Vector3.zero;
    }

    void LookForDetectable()
    {
        detector.Rotate(Vector3.up * detectionDifficulty);
        RaycastHit hit;
        Debug.DrawRay(detector.position, detector.forward * detectDistance, Color.red);
        if (Physics.Raycast(detector.position, detector.forward, out hit, detectDistance))
        {
            hitTransform = hit.transform;
            currentDetected = hitTransform.gameObject.GetComponent<Detectable>();
            if (currentDetected != null)
            {
                currentDetected.DetectionHit(this);
            }
        }
    }
}
