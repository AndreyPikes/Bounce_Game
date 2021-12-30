using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameVersionToText : MonoBehaviour
{
    [SerializeField] Text text;

    void Start()
    {
        text.text = "ver. " + Application.version;
    }

    
}
