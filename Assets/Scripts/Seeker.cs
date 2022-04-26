using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Enemy
{
    public event Action<Detectable> OnDetected = delegate { };


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

    private void OnEnable() {
        Detectable.OnDetected += Detect;
        Detectable.OnDetectionEnds += EndDetect;
    }

    private void OnDisable() {
        Detectable.OnDetected -= Detect;
        Detectable.OnDetectionEnds -= EndDetect;
    }

    private void Update()
    {
        LookForDetectable();
    }

     private void Detect(Transform obj)
    {
        //Start follow enemy.
        Debug.Log("Seeker.Detect");
    }
    
    private void EndDetect(Transform obj)
    {
        //End follow enemy.
        Debug.Log("Seeker.EndDetect");
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
                currentDetected.DetectionHit();
            }
        }
    }
}
