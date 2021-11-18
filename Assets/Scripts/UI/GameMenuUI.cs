using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenuUI : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu; //панель меню паузы
    private bool pauseMenuIsActive = false;

    private void Start()
    {
        Time.timeScale = 1; //на случай, если перезапускаем сцену из главного меню после паузы
    }



    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenuIsActive)
        {
            pauseMenuIsActive = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuIsActive) ResumeButton();
    }
    /// <summary>
    /// Метод для кнопки "Продолжить" возвращает в игру
    /// </summary>
    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
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
