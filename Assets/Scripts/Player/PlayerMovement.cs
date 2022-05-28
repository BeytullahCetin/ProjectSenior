using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    public static event Action<Vector2> OnMovement = delegate { };
    public static event Action<bool> OnCrouch = delegate { };

    [Range(1, 10)]
    [SerializeField] float movementSpeed = 3f;
    [Range(1.5f, 5f)]
    [SerializeField] float runSpeedMultiplier = 2f;

    [SerializeField] AudioSource footStepAudioSource;
    [SerializeField] AudioClip[] footSteps;
    [Range(1, 10)]
    [SerializeField] float movementFootStepSpeed = 1f;
    [Range(1.5f, 5f)]
    [SerializeField] float runFootStepSpeed = 2f;
    [Range(.1f, 5f)]
    [SerializeField] float stepInterval = 2f;


    Vector2 movementInput;
    Vector3 movement;
    float currentStepInterval;
    List<Coroutine> stepCoroutines = new List<Coroutine>();
    Coroutine stepCoroutine;

    [Header("States")]
    bool isMoving = false;
    public bool IsMoving { get { return isMoving; } }
    bool isRunning = false;
    public bool IsRunning { get { return isRunning; } }
    bool isCrouching = false;

    void Start()
    {
        currentStepInterval = stepInterval;
    }

    void Update()
    {
        transform.Translate(movement * Time.deltaTime * (isRunning && movement.z > 0 ? runSpeedMultiplier : 1));
        if (currentStepInterval >= 0)
            currentStepInterval -= isRunning == false ? movementFootStepSpeed : runFootStepSpeed;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (stepCoroutine != null)
            StopCoroutine(stepCoroutine);

        movementInput = context.ReadValue<Vector2>();

        movement.x = movementInput.x;
        movement.z = movementInput.y;
        movement *= movementSpeed;

        isMoving = movement.z > 0;

        Debug.Log(movementInput);

        stepCoroutine = StartCoroutine(StarStepSound());

        OnMovement(movementInput);
    }

    IEnumerator StarStepSound()
    {
        while (movementInput.magnitude > 0)
        {
            Step();
            yield return new WaitForSeconds(stepInterval / (isRunning == false ? movementFootStepSpeed : runFootStepSpeed));
        }
    }

    public void OnRunInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (isRunning)
            {
                case true:
                    isRunning = false;
                    break;

                case false:
                    if (!isCrouching)
                        isRunning = true;
                    break;
            }
        }
    }

    public void OnCrouchInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (isCrouching)
            {
                case true:
                    isCrouching = false;
                    break;

                case false:
                    //Slide mechanic can be handled here.
                    isRunning = false;
                    isCrouching = true;
                    break;
            }

            OnCrouch(isCrouching);
        }
    }

    void Step()
    {
        AudioClip stepClip = GetRandomStep();
        footStepAudioSource.PlayOneShot(stepClip);
    }

    private AudioClip GetRandomStep()
    {
        return footSteps[Random.Range(0, footSteps.Length)];
    }
}
