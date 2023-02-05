using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneCollider : MonoBehaviour
{
    public AgarreController agarre;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AgarreIzq"))
        {
            agarre.agarreIzq = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AgarreIzq"))
        {
            agarre.agarreIzq = false;
        }
    }
}
