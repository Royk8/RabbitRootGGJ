using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ControlPuntos : MonoBehaviour
{
    public TextMeshProUGUI puntuacionText;
    public int puntuacionZanahoria;

    public static ControlPuntos unico;

    void Start()
    {
        unico = this;
    }

    public void SumarPuntos() 
    {
        puntuacionZanahoria++;
        puntuacionText.text = puntuacionZanahoria.ToString() + " zanahorias";
    }

}
