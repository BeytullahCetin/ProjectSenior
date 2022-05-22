using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLightning : MonoBehaviour
{
    [SerializeField] Renderer[] objects;
    [SerializeField] Material[] materials;

    public void ChangeMaterial(int index)
    {
        foreach (Renderer obj in objects)
        {
            obj.material = materials[index];
        }
    }
}
