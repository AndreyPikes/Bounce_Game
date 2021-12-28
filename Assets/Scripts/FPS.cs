using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public Text text;
    private int x;
    void Update()
    {
        x = (int)(1f / Time.unscaledDeltaTime);
        if (x < 50) text.text = x.ToString();
    }
}
