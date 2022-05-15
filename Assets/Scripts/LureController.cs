using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LureController : MonoBehaviour
{
    Enemy[] EnemiesToLure;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Enemy enemy in EnemiesToLure)
            {
            }
        }
    }
}
