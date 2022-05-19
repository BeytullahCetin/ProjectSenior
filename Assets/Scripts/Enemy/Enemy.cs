using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public static Action OnGameOver = delegate { };

    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] float gameOverDistance = 1f;


    [SerializeField] protected Transform playerTransform;
    float distanceBetweenPlayer;

    private void Awake()
    {
        Reset();

    }

    private void Reset()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
