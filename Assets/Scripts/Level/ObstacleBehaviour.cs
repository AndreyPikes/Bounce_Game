using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bounce.Inputs;
using UnityEngine.UI;

public class ObstacleBehaviour : MonoBehaviour
{
    [SerializeField] private Canvas canvasKeyDoor;
    [SerializeField] private GameObject removingWalls;
    [SerializeField] private GameObject effectExplosion;

    private EventHandler openButton;    
    private bool isInSensor = false;
    private bool isSelfDamaged = false;

    private InputKeyboard inputKeyboard;

    private void Start()
    {
        inputKeyboard = new InputKeyboard();

        if (canvasKeyDoor == null) isSelfDamaged = true;
        else
        {
            openButton = canvasKeyDoor.GetComponentInChildren<EventHandler>();
            Text message = canvasKeyDoor.GetComponentInChildren<Text>();

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
        if (other.CompareTag("Player"))
        {
            if (!isSelfDamaged)
            {
                canvasKeyDoor.enabled = true;
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
            canvasKeyDoor.enabled = false;
        }
    }



    private void Update()
    {
        if (inputKeyboard.GetInputOpen() || (openButton != null && openButton.isDown)) DestroyObstacle();
        
    }

    public void DestroyObstacle()
    {
        if (!isSelfDamaged && isInSensor)
        {
            effectExplosion.SetActive(true);
            canvasKeyDoor.enabled = false;
            removingWalls.SetActive(false);
        }
    }
}
