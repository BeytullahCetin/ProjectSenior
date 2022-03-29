using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earless : MonoBehaviour
{
    public static event Action<Transform, Transform> OnEnemyDetectStarted = delegate { };

    [SerializeField] float detectDistance = 10f;
    [SerializeField] float detectionDifficulty = 1f;

    Transform detector;
    Transform hitTransform;
    RaycastHit hit;

    Vector3 targetDistanceVector;
    [SerializeField] float stopDistance = 1f;

    void OnEnable()
    {
        DetectableObject.OnDetected += FollowDetectedObject;
    }

    void OnDisable()
    {
        DetectableObject.OnDetected -= FollowDetectedObject;
    }

    void FollowDetectedObject(Transform spotted, Transform detector)
    {   
        if (detector != transform)
            return;
        
        Debug.Log("FollowDetectedObject");

        targetDistanceVector = spotted.position - transform.position;
        Debug.Log(targetDistanceVector);
        if (stopDistance < targetDistanceVector.magnitude)
        {
            transform.position += targetDistanceVector.normalized;
        }
    }

    private void Start()
    {
        CreateDetector();
    }

    void Update()
    {
        LookForEnemy();
    }

    void CreateDetector()
    {
        detector = new GameObject("Detector").transform;
        detector.parent = transform;
        detector.localPosition = Vector3.zero;
    }

    void LookForEnemy()
    {
        detector.Rotate(Vector3.up * detectionDifficulty);
        RaycastHit hit;
        Debug.DrawRay(detector.position, detector.forward * detectDistance, Color.red, .1f);
        if (Physics.Raycast(detector.position, detector.forward, out hit, detectDistance))
        {
            hitTransform = hit.transform;
            if (hitTransform.gameObject.GetComponent<DetectableObject>() != null)
            {
                OnEnemyDetectStarted(transform, hitTransform);
            }
        }
    }

}
