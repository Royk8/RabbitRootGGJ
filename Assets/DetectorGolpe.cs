using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorGolpe : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            VidaConejo.Instance.CausarDaño(1);
        }
    }

}
