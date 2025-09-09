using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spines : MonoBehaviour
{
    [SerializeField] private Vector2 limitUpper;
    [SerializeField] private Vector2 limitLower;

    private bool spines;

    private void Start()
    {
        spines = true;
    }

    public void Retract()
    {
        this.transform.localScale = Vector2.Lerp(limitUpper, limitLower, 1);
        spines = false;
    }

    public void Extend()
    {
        this.transform.localScale = Vector2.Lerp(limitLower, limitUpper, 1);
        spines = true;
    }

    public bool IsSpiney()
    {
        return spines;
    }
}
