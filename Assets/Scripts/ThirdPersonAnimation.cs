using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    Vector2 movementInput;
    Vector3 movement;

    private void Update()
    {
        Animate(movement);
    }

    public void OnAnimationInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        movement = new Vector3(movementInput.x, 0, movementInput.y);
    }

    void Animate(Vector3 movement)
    {
        //Play Animation
        animator.SetBool("Walk", movement.magnitude > 0 ? true : false);
        if (movement.z < 0)
            animator.SetFloat("WalkDirection", -1f);
        else
            animator.SetFloat("WalkDirection", 1f);
    }

}
