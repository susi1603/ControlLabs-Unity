//Echauri Modificado B (funciona correctamente, el puerto COM no funcionaba y lo desintale e instale en el Device Manager de Windows, movi el puerto a un COM menor a 10, y en Arduino elimine el espacio final del último datos (sólo hay 3 espacios en blanco)
//Para que funcione, hay que conectar el Dropdown>Label al field PuertoArduino en el Inspector
//Para que funcione el audio, se debe conectar un objeto de audio (sin Play at awake) al field audioSource_Helice en el inspector
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using UnityEngine.UI;
using UnityEngine.Audio;

public class RotatePalanca : MonoBehaviour
{
    public GameObject Palanca;
    public GameObject Helice1;
    public GameObject Helice2;
    public SerialPort serialPort;
    public float[] floatData = new float[4];
    public Boolean serial_connected = false;
    public Text PuertoArduino;

    // animatio propellers
    float sim_maxw_motor = 94.0f;  // rounded 
    float maxw_motor = 7.0f;   // maximum expected value

    // animation audio
    public AudioSource audioSource_Helice;
    private float meanAngularVel_Helice = 0.0f;
    private int counter = 0;
    private Boolean audioIniciado = false;

    void Start()
    {
        // audio animation
        audioSource_Helice.loop = true;
    }

    void Update()
    {
        if (!serial_connected)
        {
            audioIniciado = false;
            audioSource_Helice.Stop();
            Debug.Log("Conectando...");
            try
            {
                serialPort = new SerialPort(PuertoArduino.text, 9600); //Quizas aqui hay un problema, cada vez que ejecuta esta instruccion se crea una instancia con el mismo puerto
                serialPort.Open();
                serialPort.ReadTimeout = 100;
                Debug.Log("Inicio");
                serial_connected = true;
            }
            catch
            {
                Debug.Log("Puerto no aceptado");
            }
        }
        else
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    floatData = Array.ConvertAll(serialPort.ReadLine().Split(" "[0]), float.Parse);
                }
                else
                {
                    Debug.Log("Puerto cerrado");
                    serial_connected = false;
                }
            }
            catch (System.Exception ex)
            {
                ex = new System.Exception();
                Debug.Log("Falla al leer puerto");
                serial_connected = false;
            }
            // animation palanca
            Palanca.transform.rotation = Quaternion.Euler(0, 0, floatData[0]);

            // animation propellers
            Helice1.transform.Rotate(Vector3.up * floatData[2] * (sim_maxw_motor / maxw_motor) * Mathf.Rad2Deg * Time.deltaTime);
            Helice2.transform.Rotate(Vector3.up * floatData[3] * (sim_maxw_motor / maxw_motor) * Mathf.Rad2Deg * Time.deltaTime);

            // animation audio, average filter for better audio animation
            if ((audioIniciado == false)&(Math.Abs(floatData[2])+Math.Abs(floatData[3])>0.0f))
            {
                audioSource_Helice.Play();
                audioIniciado = true;
            }
            meanAngularVel_Helice = meanAngularVel_Helice + Math.Max(floatData[2], floatData[3]);            
            counter = counter + 1;
            if (counter > 3)
            { 
                counter = 0;
                audioSource_Helice.pitch = 2.0f* Math.Abs(meanAngularVel_Helice) / (3.0f *maxw_motor)+1.0f;
                meanAngularVel_Helice = 0.0f;
            }
        }
    }
}