using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using UnityEngine.UI;

public class Conexionarduino : MonoBehaviour
{
    public int[] data2;
    public int i = 0;
    //public SerialPort serialPort = new SerialPort("COM3", 9600);
    //void Start()
    //{
    //    serialPort.Open();
    //    serialPort.ReadTimeout = 1000;
    //}

    //void Update()
    //{
    //    try
    //    {
    //        if (serialPort.IsOpen)
    //        {
    //            print(serialPort.ReadLine());
    //            //Vel=int.Parse(serialPort.ReadLine());
    //        }
    //    }catch (System.Exception ex)
    //    {
    //        ex = new System.Exception();
    //    }
    //    for (i = 0; i < 3; i++)
    //    {
    //        data2[i]= int.Parse(serialPort.ReadLine());
    //    }
        
    //}




   // void RPM(int Vel_R)
    //{
     //   if(Vel_R<0)
     //   {
     //       Vel_R = 0;
     //   }
     //    transform.position = new Vector3(transform.position.x, Vel_R, transform.position.z);
   // }
}
