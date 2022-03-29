using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earless : MonoBehaviour
{
    public static event Action<Transform> OnEnemyDetectStarted = delegate { };

    [SerializeField] float detectDistance = 10f;
    [SerializeField] float detectionDifficulty = 1f;

    Transform detector;
    Transform hitTransform;
    RaycastHit hit;

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
                OnEnemyDetectStarted(hitTransform);
            }
        }
    }

}
