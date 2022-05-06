using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WatcherAnimation : MonoBehaviour
{
    [SerializeField] float speed;

    NavMeshAgent navMeshAgent;
    Animator anim;

    private static int ANIMATOR_PARAM_WALK_SPEED = 
    	Animator.StringToHash("WalkSpeed");

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        speed = navMeshAgent.velocity.magnitude;
        anim.SetFloat(ANIMATOR_PARAM_WALK_SPEED, speed);
    }
}
