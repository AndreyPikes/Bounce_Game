using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    private Image image;

    
    
    private void Start()
    {
        image = GetComponent<Image>();
        FadeTransparent(1f);
    }

    public void FadeBlack(float delay)
    {
        StartCoroutine(FadeBlackCoroutine(delay));
    }

    public void FadeTransparent(float delay)
    {
        image.color = Color.black;
        StartCoroutine(FadeTransparentCoroutine(delay));
    }

    IEnumerator FadeBlackCoroutine(float delay)
    {
        while(image.color.a < 1)
        {
            Debug.Log(image.color.a);
            image.color = Color.Lerp(image.color, new Color(0, 0, 0, 1),  (float) 1 / 20);
            yield return new WaitForSeconds(delay / 20);
        }        
        
    }
    IEnumerator FadeTransparentCoroutine(float delay)
    {
        while (image.color.a > 0)
        {
            Debug.Log(image.color.a);
            image.color = Color.Lerp(image.color, new Color(0, 0, 0, 0), (float)1 / 20);
            yield return new WaitForSeconds(delay / 20);
        }

    }
}
