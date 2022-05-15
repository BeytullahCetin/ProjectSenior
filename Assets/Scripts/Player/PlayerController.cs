using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float throwForce = 1f;
    public float ThrowForce { get { return throwForce; } }
}
