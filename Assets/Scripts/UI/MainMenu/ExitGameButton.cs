using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameButton : MonoBehaviour
{    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LinkToInstaVR()
    {
        Application.OpenURL("https://instavr.ru/");
    }
}
