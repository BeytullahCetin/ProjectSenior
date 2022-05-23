using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Detectable;

public class Watcher : Enemy
{
    [SerializeField] float detectDistance = 10f;
    [SerializeField] float sightAngle = 180;

    Transform detector;
    Transform hitTransform;
    RaycastHit hit;
    Detectable currentDetected;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        CreateDetector();
        StartCoroutine(LookForDetectable(detector, sightAngle));
    }

    void CreateDetector()
    {
        detector = new GameObject("Detector").transform;
        detector.parent = transform;
        detector.localPosition = Vector3.zero + new Vector3(0, 1, 0);
        detector.localRotation = Quaternion.identity;
    }

    IEnumerator LookForDetectable(Transform detector, float sightAngle)
    {
        bool toPositive = true;
        sightAngle = sightAngle / 2;

        while (true)
        {
            if (toPositive)
            {
                detector.Rotate(Vector3.up * 5);
                if (detector.localRotation.eulerAngles.y > sightAngle && detector.localRotation.eulerAngles.y < 180)
                    toPositive = false;
            }
            else
            {
                detector.Rotate(Vector3.down * 5);
                if (detector.localRotation.eulerAngles.y < 360 - sightAngle && detector.localRotation.eulerAngles.y > 180)
                    toPositive = true;
            }

            RaycastHit hit;
            Debug.DrawRay(detector.position, detector.forward * detectDistance, Color.red);
            if (Physics.Raycast(detector.position, detector.forward, out hit, detectDistance))
            {
                hitTransform = hit.transform;
                currentDetected = hitTransform.gameObject.GetComponent<Detectable>();
                if (currentDetected != null)
                {
                    currentDetected.ShootDetectionHit(this);
                }
            }

            yield return null;
        }
    }
}
