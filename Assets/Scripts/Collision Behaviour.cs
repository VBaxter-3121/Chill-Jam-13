using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionBehaviour : MonoBehaviour
{
    private Spines spines;
    private Vector2 jumpDirection;

    // Start is called before the first frame update
    void Start()
    {
        spines = this.GetComponent<Spines>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<SurfaceProperties>().IsSoft())
        {
            Debug.Log("This surface is soft.");
            if (spines.IsSpiney())
            {
                Debug.Log("I can stick to this surface.");
            }
        }
        else
        {
            Debug.Log("This surface is hard.");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.transform.GetComponent<SurfaceProperties>().IsSoft() && !spines.IsSpiney())
        {
            jumpDirection = collision.GetContact(0).normal;
        }
        else
        {
            jumpDirection = Vector2.zero;
        }
    }

    public Vector2 GetJumpDirection()
    {
        return jumpDirection;
    }
}
