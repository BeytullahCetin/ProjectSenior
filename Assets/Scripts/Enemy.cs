using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;

    private void Reset()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //navMeshAgent.updatePosition = false;
    }

    public void Detect(Detectable obj)
    {
        //Start follow enemy.
        Debug.Log("Seeker.Detect");
        navMeshAgent.SetDestination(obj.transform.position);
    }

    public void EndDetect(Detectable obj)
    {
        //End follow enemy.
        Debug.Log("Seeker.EndDetect");
    }
}
