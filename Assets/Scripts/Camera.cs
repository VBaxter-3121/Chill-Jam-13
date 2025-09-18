using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject cactus;

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(cactus.transform.position.x, cactus.transform.position.y, -10);
    }
}
