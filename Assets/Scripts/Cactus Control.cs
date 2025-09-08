using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CactusControl : MonoBehaviour
{

    public void RetractSpines(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            this.GetComponent<Spines>().Retract();
        }
        else if (context.canceled)
        {
            this.GetComponent<Spines>().Extend();
        }
    }
}
