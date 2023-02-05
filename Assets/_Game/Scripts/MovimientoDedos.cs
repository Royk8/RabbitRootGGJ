using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class MovimientoDedos : MonoBehaviour
{
    public SerialPort puerto = new SerialPort("COM3", 9600);
    public Vector3 datosArduino;


    // Start is called before the first frame update
    void Start()
    {
        puerto.ReadTimeout = 1000;
        puerto.Open();
    }

    // Update is called once per frame
    void Update()
    {

        if (puerto.IsOpen)
        {
            print("Conectado");
            string datoRecibido = puerto.ReadLine();
            string[] datos = datoRecibido.Split('|');
            if (datos.Length == 3)
            {
                datosArduino = new Vector3((float.Parse(datos[0])) / 180, (float.Parse(datos[1])) / 180, (float.Parse(datos[2])) / 180);
            }
            Debug.Log(datoRecibido);
        }
    }
}