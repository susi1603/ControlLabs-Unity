using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using UnityEngine.UI;

public class RotateeliceR : MonoBehaviour
{
   
    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(Vector3.up * 10000 * Time.deltaTime);
    }

}