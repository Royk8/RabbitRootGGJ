using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaConejo : MonoBehaviour
{
    #region Singleton
    public static VidaConejo Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
    }
    #endregion
    public float vidaInicial;
    public float vidaActual;

        
    float vidaPorcentual;
    
    void Start()
    {
        vidaInicial = vidaActual;
        
        
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
    
    
}
