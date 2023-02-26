using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ValuesMenu : MonoBehaviour
{
    public RotatePalanca rotate_Palanca; 


    public Text Angle_data;
    public Text VelR_data;
    public Text VelL_data;
    public Text VelAng_data;


    void Start()
    {
        rotate_Palanca = GameObject.Find("Palanca").GetComponent<RotatePalanca>();
    }

    
    void Update()
    {

        Angle_data.text = rotate_Palanca.floatData[0].ToString("F2");
        VelR_data.text= rotate_Palanca.floatData[2].ToString("F2");
        VelL_data.text= rotate_Palanca.floatData[3].ToString("F2");
        VelAng_data.text = rotate_Palanca.floatData[1].ToString("F2");

    }
}
