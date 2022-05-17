using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] float gameOverDistance = 2f;

    public static Action OnGameOver = delegate { };

    [SerializeField] Transform playerTransform;
    float distanceBetweenPlayer;


    private void Reset()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //navMeshAgent.updatePosition = false;
    }

    public void GoToPosition(Vector3 destination)
    {
        navMeshAgent.SetDestination(destination);
        Debug.Log(name + ": GoToPosition");
    }

    public void Detect(Detectable obj)
    {
        //Start follow enemy.
        navMeshAgent.SetDestination(obj.transform.position);
        CheckGameOver();
    }

    public void EndDetect(Detectable obj)
    {
        //End follow enemy.
        Debug.Log("Seeker.EndDetect");
    }

    public void CheckGameOver()
    {
        distanceBetweenPlayer = (transform.position - playerTransform.position).magnitude;
        if (distanceBetweenPlayer < gameOverDistance)
        {
            OnGameOver();
        }
    }
}
