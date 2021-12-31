using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Bounce.Inputs;
using System;

public class GameMenuUI : MonoBehaviour
{
    [SerializeField] public PlayerPresenter playerPresenter;
    [SerializeField] private Canvas pauseMenuCanvas; //панель меню паузы
    [SerializeField] private Canvas playerMobileControllerInputCanvas; //панель управления игроком
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] public Canvas keyDoorCanvas;
    [SerializeField] private float deathCanvasDelay;

    private bool pauseMenuIsActive = false;
    private InputKeyboard inputKeyboard;
    [HideInInspector]public bool playerDead = false;

    private void Start()
    {
        Time.timeScale = 1; //на случай, если перезапускаем сцену из главного меню после паузы
        inputKeyboard = new InputKeyboard();
        playerPresenter.playerModel.Death += PlayerDeathCoroutine;        


#if UNITY_ANDROID || UNITY_IOS
        playerMobileControllerInputCanvas.enabled = true;        
#endif
    }

    private void PlayerDeathCoroutine(string notificationText)
    {
        StartCoroutine(PlayerDeathCanvasShow(notificationText));
    }

    private IEnumerator PlayerDeathCanvasShow(string notificationText)
    {
        playerDead = true;
        playerMobileControllerInputCanvas.enabled = false;
        yield return new WaitForSeconds(deathCanvasDelay);
        gameOverCanvas.enabled = true;
        Text message = gameOverCanvas.gameObject.GetComponentInChildren<Text>();
        message.text = notificationText;
    }

    private void Update()
    {
        if (!playerDead && inputKeyboard.GetInputEscape())
        {
            PauseButton();
        }
    }

    
    public void PauseButton()
    {
        if (!pauseMenuIsActive)
        {
            pauseMenuIsActive = true;
            pauseMenuCanvas.enabled = true;
            Time.timeScale = 0;
        }
        else ResumeButton();
    }

    /// <summary>
    /// Метод для кнопки "Продолжить" возвращает в игру
    /// </summary>
    public void ResumeButton()
    {
        pauseMenuCanvas.enabled = false;
        Time.timeScale = 1;
        pauseMenuIsActive = false;
    }
    /// <summary>
    /// Метод для кнопки возврата в главное меню
    /// </summary>
    public void ReturnToMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    /// <summary>
    /// Метод для перезапуска данной сцены
    /// </summary>
    public void RestartLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
