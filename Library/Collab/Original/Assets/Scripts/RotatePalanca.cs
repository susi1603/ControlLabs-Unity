using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using UnityEngine.UI;

public class RotatePalanca : MonoBehaviour
{
    public SerialPort serialPort = new SerialPort("COM3", 9600);
    public int Angle;
    void Start()
    {
        serialPort.Open();
        serialPort.ReadTimeout = 100;
    }


    void Update()
    {
        try
        {
            if (serialPort.IsOpen)
            {
                print(serialPort.ReadLine());
                Angle = int.Parse(serialPort.ReadLine());
            }
        }
        catch (System.Exception ex)
        {
            ex = new System.Exception();
        }
        Quaternion rot = new Quaternion();
        rot.eulerAngles = new Vector3(0, 0, Angle);
        transform.rotation = rot;
        transform.rotation=Quaternion.Euler(0, 0, Angle);
        
    }
}