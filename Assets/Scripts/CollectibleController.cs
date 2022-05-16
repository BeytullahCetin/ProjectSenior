using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleController : MonoBehaviour
{
    Canvas UI;
    TextMeshProUGUI UIText;

    Transform playerTransform;
    protected bool canInteractable;
    bool canRotate;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Reset() {
        UI = GetComponentInChildren<Canvas>();
        UIText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public virtual void Interaction()
    {
        if (canInteractable)
            Debug.Log("Interaction CollectibleController");
    }

    void Update()
    {
        if (canRotate)
            UIText.transform.LookAt(2 * transform.position - playerTransform.position);
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
