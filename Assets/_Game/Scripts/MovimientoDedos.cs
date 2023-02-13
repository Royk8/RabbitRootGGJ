using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class MovimientoDedos : MonoBehaviour
{
    public SerialPort puerto = new SerialPort("COM3", 115200);
    public Vector3 datosArduino;
    public Vector3 datosArduino2;



    // Start is called before the first frame update
    void Start()
    {
        puerto.ReadTimeout = 1000;
        puerto.Open();
        StartCoroutine(Lectura());
    }

    private void Update()
    {
        datosArduino2 = Vector3.Lerp(datosArduino2, datosArduino, Time.deltaTime * 3); 
    }

    // Update is called once per frame
    IEnumerator Lectura()
    {
        while (true)
        {
            if (puerto.IsOpen)
            {
                print("Conectado");
                string datoRecibido = "Control";
                datoRecibido = puerto.ReadLine();
                yield return new WaitUntil(() => datoRecibido != "Control");
                /*string[] datos = datoRecibido.Split('|');
                if (datos.Length == 3)
                {
                    datosArduino = new Vector3((float.Parse(datos[0])) / 180, (float.Parse(datos[1])) / 180, (float.Parse(datos[2])) / 180);
                }
                */
                int r = int.Parse(datoRecibido);
                datosArduino.z = ((float)r % 10) / 9f;
                r = (r - r % 10) / 10;
                datosArduino.y = ((float)r % 10) / 9f;
                r = (r - r % 10) / 10;
                datosArduino.x = ((float)r % 10) / 9f;       
                Debug.Log(datoRecibido);
            }
            yield return new WaitForSeconds(0.25f);
        }
        
    }
}