using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class CollisionBehaviour : MonoBehaviour
{
    private Spines spines;
    private Vector2 jumpDirection;
    public SplineContainer splineContainer;
    private bool freeMovement;
    BezierKnot startKnot;
    BezierKnot endKnot;

    // Start is called before the first frame update
    void Start()
    {
        spines = this.GetComponent<Spines>();
        freeMovement = true;
    }

    private void Update()
    {
        if (!freeMovement)
        {
            float3 nearestPoint;
            float t;
            SplineUtility.GetNearestPoint(splineContainer.Spline, transform.position, out nearestPoint, out t);
            this.transform.position = nearestPoint;
            if (this.transform.position == splineContainer.transform.TransformPoint(startKnot.Position) ||
                this.transform.position == splineContainer.transform.TransformPoint(endKnot.Position))
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

            //GetComponent<Rigidbody2D>().AddForce(GetComponent<Rigidbody2D>().velocity * -0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<SurfaceProperties>().IsSoft())
        {
            //Debug.Log("This surface is soft.");
            if (spines.IsSpiney())
            {
                //Debug.Log("I can stick to this surface.");
                splineContainer = collision.transform.GetComponent<SurfaceProperties>().GetSpline();
                startKnot = splineContainer.Spline[0];
                endKnot = splineContainer.Spline[splineContainer.Spline.Count - 1];
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                freeMovement = false;
                this.GetComponent<CactusControl>().ToggleSpeed(freeMovement);
            }
        }
        else
        {
            //Debug.Log("This surface is hard.");
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

        if (collision.transform.GetComponent<SurfaceProperties>().IsSoft() && spines.IsSpiney() && freeMovement)
        {
            splineContainer = collision.transform.GetComponent<SurfaceProperties>().GetSpline();
            startKnot = splineContainer.Spline[0];
            endKnot = splineContainer.Spline[splineContainer.Spline.Count - 1];
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            freeMovement = false;
            this.GetComponent<CactusControl>().ToggleSpeed(freeMovement);
        }
    }

    public Vector2 GetJumpDirection()
    {
        return jumpDirection;
    }

    public void Release()
    {
        freeMovement = true;
        this.GetComponent<CactusControl>().ToggleSpeed(freeMovement);
        splineContainer = null;
    }

    public bool IsStuck()
    {
        return freeMovement;
    }
}
