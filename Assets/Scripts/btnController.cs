using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnController : MonoBehaviour
{
   public ChangeTexture changeTexture; 

    // Start is called before the first frame update
    void Awake()
    {
    }

    public void rightClick() 
    {
        changeTexture.goUp();
    }

    public void leftClick()
    {
        changeTexture.goDown();
    }


}
