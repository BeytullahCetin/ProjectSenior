using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleController : MonoBehaviour
{
    [SerializeField] Canvas UI;
    [SerializeField] TextMeshProUGUI UIText;


    Transform playerTransform;
    bool canInteractable;
    bool canRotate;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void Interaction()
    {
        if (canInteractable)
            Debug.Log("Interaction");
    }

    void Update()
    {
        if (canRotate)
            UIText.transform.LookAt(2 * transform.position - playerTransform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        canRotate = true;
        canInteractable = true;
        ShowUI();
    }

    void ShowUI()
    {
        UI.enabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        canRotate = false;
        canInteractable = false;
        HideUI();
    }

    void HideUI()
    {
        UI.enabled = false;
    }
}
