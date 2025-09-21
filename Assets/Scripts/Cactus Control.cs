using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;

public class CactusControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpStrength;
    [SerializeField] private Sprite big;
    [SerializeField] private Sprite small;

    private Vector2 moveDirection;
    private float baseSpeed;
    private bool free;
    Collision2D currectCollider;

    private void Start()
    {
        baseSpeed = moveSpeed;
        free = true;
    }

    private void FixedUpdate()
    {
        if (free)
        {
            moveDirection.y = 0;
        }
        else
        {
            moveDirection += currectCollider.GetContact(0).normal * -0.05f;
        }
        rb.AddForce(moveDirection * moveSpeed);
        Debug.Log(moveDirection);
    }

    public void RetractSpines(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            free = true;
            this.GetComponent<Spines>().Retract();
            this.GetComponent<CollisionBehaviour>().Release();
            this.GetComponent<SpriteRenderer>().sprite = small;
        }
        else if (context.canceled)
        {
            this.GetComponent<Spines>().Extend();
            rb.AddForce(this.GetComponent<CollisionBehaviour>().GetJumpDirection() * jumpStrength);
            this.GetComponent<SpriteRenderer>().sprite = big;
        }
    }

    public void Roll(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    public void ToggleSpeed(bool isFree, Collision2D collider)
    {
        free = isFree;
        if (!free)
        {
            moveSpeed = baseSpeed * 0.5f;
            rb.gravityScale = 0.25f;
            currectCollider = collider;
        }
        else
        {
            if (currectCollider != null)
            {
                moveDirection = Vector2.zero;
            }
            moveSpeed = baseSpeed;
            rb.gravityScale = 1;
            currectCollider = null;
        }
    }
}
