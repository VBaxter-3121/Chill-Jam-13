using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spines : MonoBehaviour
{
    [SerializeField] private Vector2 limitUpper;
    [SerializeField] private Vector2 limitLower;
    [SerializeField] private float spineSpeed;

    private bool isRetracting;

    private void Start()
    {
        isRetracting = false;
    }

    private void Update()
    {
        //if (isRetracting && this.transform.localScale.x > limitLower)
        //{
        //    this.transform.localScale -= Vector3.one * Time.deltaTime * spineSpeed;
        //}
        //else if (!isRetracting && this.transform.localScale.x < limitUpper)
        //{
        //    this.transform.localScale += Vector3.one * Time.deltaTime * spineSpeed;
        //}
    }

    public void Retract()
    {
        //isRetracting = true;
        this.transform.localScale = Vector2.Lerp(limitUpper, limitLower, 1);
    }

    public void Extend()
    {
        //isRetracting = false;
        this.transform.localScale = Vector2.Lerp(limitLower, limitUpper, 1);
    }
}
