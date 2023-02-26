using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{
    public Texture[] textures;
    int indexTexture; 

    Renderer m_Renderer;

    void Awake()
    {
        indexTexture = 0;
        m_Renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        m_Renderer.material.SetTexture("_MainTex", textures[indexTexture]);

    }

    public void goUp()
    {
        if (indexTexture < (textures.Length - 1))
        {
            indexTexture++;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (indexTexture < (textures.Length - 1))
            {
                indexTexture--;
            }
               
        }

        }

    public void goDown()
    {

      if (indexTexture > 0) {
        indexTexture--;
      }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (indexTexture > 0)
            {
                indexTexture++;
            }
        }

    }

}
