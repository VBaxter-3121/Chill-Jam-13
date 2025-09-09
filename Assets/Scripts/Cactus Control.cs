using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CactusControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpStrength;

    private Vector2 moveDirection;

    private void FixedUpdate()
    {
        rb.AddForce(moveDirection * moveSpeed);
    }

    public void RetractSpines(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            this.GetComponent<Spines>().Retract();
        }
        else if (context.canceled)
        {
            this.GetComponent<Spines>().Extend();
            rb.AddForce(this.GetComponent<CollisionBehaviour>().GetJumpDirection() * jumpStrength);
        }
    }

    public void Roll(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }
}
