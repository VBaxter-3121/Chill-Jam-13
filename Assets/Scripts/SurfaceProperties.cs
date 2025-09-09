using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceProperties : MonoBehaviour
{
    [SerializeField] private bool soft;
    public bool IsSoft()
    {
        return soft;
    }
}
