using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishSensor : MonoBehaviour
{
    [SerializeField] private Fader fader;
    [SerializeField] private Canvas canvasWinGame;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(NextLevelTransition());
        }        
    }

    private IEnumerator NextLevelTransition()
    {
        canvasWinGame.enabled = true;
        yield return new WaitForSecondsRealtime(2f);
        fader.FadeBlack(0.2f);
        yield return new WaitForSecondsRealtime(0.2f);
        canvasWinGame.enabled = false;
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }        
    }
}
