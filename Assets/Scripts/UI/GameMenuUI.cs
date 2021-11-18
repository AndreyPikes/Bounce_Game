using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenuUI : MonoBehaviour
{
    [SerializeField] Canvas pauseMenu; //панель меню паузы
    [SerializeField] Canvas playerMobileControllerInput; //панель меню паузы
    private bool pauseMenuIsActive = false;

    private void Start()
    {
        Time.timeScale = 1; //на случай, если перезапускаем сцену из главного меню после паузы

#if UNITY_ANDROID
        playerMobileControllerInput.enabled = true;        
#endif
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenuIsActive)
        {
            pauseMenuIsActive = true;
            pauseMenu.enabled = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuIsActive) ResumeButton();

#if UNITY_ANDROID
        

#endif

    }
    /// <summary>
    /// Метод для кнопки "Продолжить" возвращает в игру
    /// </summary>
    public void ResumeButton()
    {
        pauseMenu.enabled = false;
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
