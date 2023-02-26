using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeText : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            GetComponent<TextMesh>().text = "Hello World";
        }

        if (Input.GetKey("down"))
        {
            GetComponent<TextMesh>().text = "Hello Fer";
        }
    }
}
