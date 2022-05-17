using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    Vector2 movementInput;
    Vector3 movement;

    private void OnEnable()
    {
        PlayerMovement.OnMovement += AnimateMovement;
        PlayerMovement.OnCrouch += AnimateCrouch;
    }

    private void OnDisable()
    {
        PlayerMovement.OnMovement -= AnimateMovement;
        PlayerMovement.OnCrouch -= AnimateCrouch;
    }

    public void OnAnimationInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        movement = new Vector3(movementInput.x, 0, movementInput.y);
    }

    void AnimateMovement(Vector2 movement)
    {
        //Play Animation
        animator.SetBool("Walk", movement.magnitude > 0 ? true : false);
        if (movement.y < 0)
            animator.SetFloat("WalkDirection", -1f);
        else
            animator.SetFloat("WalkDirection", 1f);
    }

    void AnimateCrouch(bool isCrouching)
    {
        animator.SetBool("Crouch", isCrouching);
    }

}
