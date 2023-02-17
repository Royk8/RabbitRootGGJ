using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorVeneno : MonoBehaviour
{
    private float damageAcumulate;

    // Start is called before the first frame update
    void Start()
    {
        damageAcumulate = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damageAcumulate += Time.deltaTime * 0.25f;
            if (damageAcumulate>1)
            {
                VidaConejo.Instance.CausarDaño(1);
                damageAcumulate = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damageAcumulate = 0;
       }
    }
}
