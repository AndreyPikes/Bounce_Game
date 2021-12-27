using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] private float fadeToTransparentDelay;
    [SerializeField] private Image image;
    [SerializeField] private Canvas canvas;
    
    private void OnEnable()
    {
        canvas.enabled = true;
        FadeTransparent(fadeToTransparentDelay);        
    }

    public void FadeBlack(float delay)
    {
        canvas.enabled = true;
        StartCoroutine(FadeToBlackCoroutine(delay));
    }

    public void FadeTransparent(float delay)
    {
        image.color = Color.black;        
        StartCoroutine(FadeToTransparentCoroutine(delay));
    }

    IEnumerator FadeToBlackCoroutine(float delay)
    {
        while (image.color.a < 1f)
        {
            float alpha = Mathf.Lerp(image.color.a, 2f, 0.05f);
            image.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSecondsRealtime(delay / 20);
        }

    }
    IEnumerator FadeToTransparentCoroutine(float delay)
    {
        while (image.color.a > 0f)
        {
            float alpha = Mathf.Lerp(image.color.a, -1f, 0.05f);
            image.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSecondsRealtime(delay / 20);
        }
        canvas.enabled = false;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
