using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] Animator animator;
    Vector2 movementInput;
    Vector3 movement;
    [SerializeField] float movementSpeed = 3f;

    private void Update()
    {
        /* if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        } */

        Move(movement);
    }

    public void OnMovementChanged(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        movement = new Vector3(movementInput.x, 0, movementInput.y);
        Debug.Log(movement);
    }

    void Move(Vector3 movement)
    {
        //Change Position
        transform.position += movement * movementSpeed * Time.deltaTime;

        //Play Animation
        animator.SetBool("Walk", movement.magnitude > 0 ? true : false);
        if (movement.z < 0)
            animator.SetFloat("WalkDirection", -1f);
        else
            animator.SetFloat("WalkDirection", 1f);

    }

}
