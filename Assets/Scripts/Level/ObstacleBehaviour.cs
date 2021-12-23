using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bounce.Inputs;
using UnityEngine.UI;

public class ObstacleBehaviour : MonoBehaviour
{
    [SerializeField] private GameMenuUI gameMenuUI;
    [SerializeField] private GameObject removingWalls;
    [SerializeField] private GameObject effectExplosion;
    [SerializeField] private bool isSelfDamaged;

    private EventHandler openButton;    
    private bool isInSensor = false;
    

    private InputKeyboard inputKeyboard;

    private void Start()
    {
        inputKeyboard = new InputKeyboard();

        if (!isSelfDamaged)
        {
            openButton = gameMenuUI.keyDoorCanvas.GetComponentInChildren<EventHandler>();
            Text message = gameMenuUI.keyDoorCanvas.GetComponentInChildren<Text>();

#if UNITY_ANDROID
        message.text =  "Press to open";
#endif
#if UNITY_STANDALONE_WIN || UNITY_WEBGL
            message.text = "Press \"E\" to open";
#endif
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !gameMenuUI.playerDead)
        {
            if (!isSelfDamaged)
            {
                gameMenuUI.keyDoorCanvas.enabled = true;
                isInSensor = true;
            }
            else
            {
                effectExplosion.SetActive(true);                
                removingWalls.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInSensor = false;
            gameMenuUI.keyDoorCanvas.enabled = false;
        }
    }



    private void Update()
    {
        if (inputKeyboard.GetInputOpen() || (openButton != null && openButton.isDown))
        {
            if (!isSelfDamaged && isInSensor) DestroyObstacle();
        }      
    }

    public void DestroyObstacle()
    {
        effectExplosion.SetActive(true);
        gameMenuUI.keyDoorCanvas.enabled = false;
        removingWalls.SetActive(false);
    }
}
