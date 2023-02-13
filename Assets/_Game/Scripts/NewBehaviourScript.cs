using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaConejo : MonoBehaviour
{
    public float vidaInicial;
    public float vidaActual;

    public Image imagen;
    float vidaPorcentual;
    
    void Start()
    {
        vidaInicial = vidaActual;
        ActualizarUI();
        
    }
        
    public void CausarDaño (float cuanto)
    {
        vidaActual -= cuanto;
        if (vidaActual <=0)
        {
            vidaActual = 0;
        }
        vidaPorcentual = vidaActual / vidaInicial;
    }
    public void ActualizarUI()
    {

    }
    
}
