using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AgarreController : MonoBehaviour
{

    public InputActionProperty inputIzq, inputDer;
    public bool agarreIzq, agarreDer;
    private bool agarrado;
    private Vector3 oldPosition;
    public ZanahoriaController zana;


    void Start()
    {
        inputIzq.action.Enable();
    }

    void Update()
    {

        if (agarreIzq && inputIzq.action.ReadValue<float>() > 0.5f)
        {
            if (agarrado)
            {
                Vector3 movement = oldPosition - ControlesSingleton.Instance.agarreIzq.position;
                zana.SetMovement(movement);
            }
            oldPosition = ControlesSingleton.Instance.agarreIzq.position;
            agarrado = true;
        }
        else
        {
            agarrado = false;
        }
    }
}
