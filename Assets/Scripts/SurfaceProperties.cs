using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SurfaceProperties : MonoBehaviour
{
    [SerializeField] private bool soft;
    [SerializeField] private SplineContainer spline;
    public bool IsSoft()
    {
        return soft;
    }
    public SplineContainer GetSpline()
    {
        return spline;
    }
}
