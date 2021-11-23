using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Bounce.Inputs;
using System;

public class GameMenuUI : MonoBehaviour
{
    [SerializeField] private PlayerPresenter playerPresenter;
    [SerializeField] private Canvas pauseMenuCanvas; //панель меню паузы
    [SerializeField] private Canvas playerMobileControllerInputCanvas; //панель управления игроком
    [SerializeField] private Canvas gameOverCanvas;

    private bool pauseMenuIsActive = false;
    private InputKeyboard inputKeyboard;
    private bool playerDead;

    private void Start()
    {
        Time.timeScale = 1; //на случай, если перезапускаем сцену из главного меню после паузы
        inputKeyboard = new InputKeyboard();
        playerPresenter.playerModel.Death += PlayerDeathCanvasShow;


#if UNITY_ANDROID
        playerMobileControllerInputCanvas.enabled = true;        
#endif
    }

    private void PlayerDeathCanvasShow(string notificationText)
    {
        playerDead = true;
        gameOverCanvas.enabled = true;
        Text message = gameOverCanvas.gameObject.GetComponentInChildren<Text>();
        message.text = notificationText;

        playerMobileControllerInputCanvas.enabled = false;

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
