using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO.Ports;

public class SerialPorts : MonoBehaviour
{
    //public int i;
    public List<string> ports = new List<string> { };
    Dropdown m_Dropdown;
    public GameObject arduinoScript;

    void Start()
    {
        m_Dropdown = GetComponent<Dropdown>();
        m_Dropdown.ClearOptions();

        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(m_Dropdown);
        });

        foreach (string port in SerialPort.GetPortNames())
        {
            ports.Add(port);
        }
        if (ports.Count > 0)
        {
            m_Dropdown.AddOptions(ports);
        }
        else {
            m_Dropdown.AddOptions(new List<string> { "No COMS found" });
            m_Dropdown.AddOptions(new List<string> { "COM1" });
            m_Dropdown.AddOptions(new List<string> { "COM2" });
        }
        

    }

    void DropdownValueChanged(Dropdown change)
    {

        Debug.Log(m_Dropdown.options[change.value].text);
    }
    //void Update()
    //{
    //    List<string> ports = new List<string> { };
    //    foreach (string port in SerialPort.GetPortNames())
    //    {

    //        
    //    }

    //    while (i == 0)
    //    {
    //        foreach (string a in ports)
    //        {
    //            print(a);
    //        }

    //        i = 1;
    //    }

    //}
}
