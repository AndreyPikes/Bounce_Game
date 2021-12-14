using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CreateLevelButton : MonoBehaviour
{
    [SerializeField] private Button sampleButton;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private Fader fader;
    private int sceneCount;  



    void Start()
    {
        sceneCount = SceneManager.sceneCountInBuildSettings; //получаем количество сцен в проекте всего
        Debug.Log($"sceneCount = {sceneCount}");
        for (int i = 1; i < sceneCount; i++) //нулевую сцену игнорируем, поскольку это меню
        {
            CreateNewButtonLinkToScene(i);      //запускаем метод создания кнопки, соответсвующей сцене
        }
    }

    /// <summary>
    /// Создание кнопки на основе индекса сцены
    /// </summary>
    /// <param name="sceneIndex">индекс сцены</param>
    private void CreateNewButtonLinkToScene(int sceneIndex)
    {
        Button sceneLinkButton = Instantiate(sampleButton, parentTransform); //создаем согласно кнопке образцу в этой же координате, поскольку точное расположение будет обеспечено Grid Layout
        Text sceneLinkButtonText = sceneLinkButton.GetComponentInChildren<Text>();
        sceneLinkButtonText.text = $"Level {sceneIndex}";

        sceneLinkButton.onClick.AddListener(() => //добавляем событие по срабатыванию новой кнопки
        {
            StartCoroutine(LoadSceneCoroutine(sceneIndex, 0.3f));
        });
    }

    IEnumerator LoadSceneCoroutine(int sceneIndex, float delay)
    {
        fader.FadeBlack(delay);        
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
