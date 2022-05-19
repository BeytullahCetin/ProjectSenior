using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableController : MonoBehaviour
{
    Canvas UI;
    GameObject UITextContainer;


    Transform playerTransform;
    protected bool canInteractable;
    bool canRotate;

    void Start()
    {
        Reset();
    }

    private void Reset()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        UI = GetComponentInChildren<Canvas>();
        UITextContainer = GetComponentInChildren<TextMeshProUGUI>().transform.parent.gameObject;
    }

    public virtual void Interaction()
    {
        if (canInteractable)
            Debug.Log("Interaction CollectibleController");
    }

    void Update()
    {
        if (canRotate)
            UITextContainer.transform.LookAt(2 * transform.position - playerTransform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canRotate = true;
            canInteractable = true;
            ShowUI();
        }
    }

    void ShowUI()
    {
        UI.enabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canRotate = false;
            canInteractable = false;
            HideUI();
        }
    }

    void HideUI()
    {
        UI.enabled = false;
    }
}
