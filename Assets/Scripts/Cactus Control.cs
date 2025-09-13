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
    private float baseSpeed;

    private void Start()
    {
        baseSpeed = moveSpeed;
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDirection * moveSpeed);
    }

    public void RetractSpines(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            this.GetComponent<Spines>().Retract();
            this.GetComponent<CollisionBehaviour>().Release();
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

    public void ToggleSpeed(bool isFree)
    {
        if (!isFree)
        {
            moveSpeed = baseSpeed * 0.5f;
            rb.gravityScale = 0.25f;
        }
        else
        {
            moveSpeed = baseSpeed;
            rb.gravityScale = 1;
        }
    }
}
