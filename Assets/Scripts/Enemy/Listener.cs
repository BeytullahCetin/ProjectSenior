using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : Enemy
{
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

}
