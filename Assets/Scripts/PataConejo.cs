using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PataConejo : MonoBehaviour
{
    public Dedo[] dedos;
    public MovimientoDedos datosAr;
    void Start()
    {
        for (int i = 0; i < dedos.Length; i++)
        {
            dedos[i].Inicializar();
        }
    }

    // Update is called once per frame
    void Update()
    {
        dedos[0].t = datosAr.datosArduino2.x;
        dedos[1].t = datosAr.datosArduino2.y;
        dedos[2].t = datosAr.datosArduino2.z;

        for (int i = 0; i < dedos.Length; i++)
		{
            dedos[i].Actualizar();
        }

    }
}

[System.Serializable]
public class Dedo
{
    [Range(0, 1)]
    public float t;
    public Transform[] falanjesBase;
    public Transform[] falanjesCerrado;

    Quaternion[] angulosAbiertos;
    Quaternion[] angulosCerrados;

    public void Inicializar()
	{
        angulosAbiertos = new Quaternion[falanjesBase.Length];
        angulosCerrados = new Quaternion[falanjesBase.Length];
		for (int i = 0; i < falanjesBase.Length; i++)
		{
            angulosAbiertos[i] = falanjesBase[i].localRotation;
            angulosCerrados[i] = falanjesCerrado[i].localRotation;
        }
	}

    public void Actualizar()
	{
        for (int i = 0; i < falanjesBase.Length; i++)
        {
            falanjesBase[i].localRotation = Quaternion.Lerp(angulosAbiertos[i], angulosCerrados[i], t);
        }
    }
}