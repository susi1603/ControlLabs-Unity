using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    public static bool arrowPause;
    public GameObject menuUI;

    void Start()
    {
        menuUI.SetActive(false);
        arrowPause = false;
    }

    public void Hide()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1f;
        arrowPause = false;
    }

    public void Show()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0f;
        arrowPause = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (arrowPause)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        if (PauseMenu.GameIsPaused)
        {
            //arrowPause = false;
            Hide();
        }
    }

}
