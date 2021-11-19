using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishSensor : MonoBehaviour
{
    Coroutine nextLevelTransitionCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        
            if (other.CompareTag("Player"))
            {
            nextLevelTransitionCoroutine = StartCoroutine(NextLevelTransition());
            }        
    }

    private IEnumerator NextLevelTransition()
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
