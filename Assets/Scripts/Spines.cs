using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spines : MonoBehaviour
{
    [SerializeField] private float limitUpper;
    [SerializeField] private float limitLower;
    [SerializeField] private float spineSpeed;

    private bool isRetracting;

    private void Start()
    {
        isRetracting = false;
    }

    private void Update()
    {
        if (isRetracting && this.transform.localScale.x > limitLower)
        {
            this.transform.localScale -= Vector3.one * Time.deltaTime * spineSpeed;
            Debug.Log(this.transform.localScale);
        }
        else if (!isRetracting && this.transform.localScale.x < limitUpper)
        {
            this.transform.localScale += Vector3.one * Time.deltaTime * spineSpeed;
            Debug.Log(this.transform.localScale);
        }
    }

    public void Retract()
    {
        isRetracting = true;
    }

    public void Extend()
    {
        isRetracting = false;
    }
}
