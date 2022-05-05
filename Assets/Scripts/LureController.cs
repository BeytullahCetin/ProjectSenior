using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Detectable))]
public class LureController : MonoBehaviour
{
    Detectable detectableComponent;

    void Reset()
    {
        detectableComponent = GetComponent<Detectable>();
        detectableComponent.enabled = false;
    }

    void Start()
    {
        detectableComponent = GetComponent<Detectable>();
        detectableComponent.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            detectableComponent.enabled = true;
        }
    }
}
