using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spines : MonoBehaviour
{
    [SerializeField] private Vector2 limitUpper;
    [SerializeField] private Vector2 limitLower;
    [SerializeField] private float spineSpeed;

    public void Retract()
    {
        this.transform.localScale = Vector2.Lerp(limitUpper, limitLower, 1);
    }

    public void Extend()
    {
        this.transform.localScale = Vector2.Lerp(limitLower, limitUpper, 1);
    }
}
