using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    [SerializeField] private Canvas infoCanvas;
    [SerializeField] private GameObject removingWalls;
    [SerializeField] private EventHandler openButton;
    [SerializeField] private GameObject effectExplosion;
    private bool isInSensor = false;
    private bool isSelfDamaged = false;

    private void Start()
    {
        if (infoCanvas == null || openButton == null) isSelfDamaged = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isSelfDamaged)
            {
                infoCanvas.enabled = true;
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
            infoCanvas.enabled = false;
        }
    }

    private void Update()
    {
        if (isInSensor && (Input.GetKey(KeyCode.E) || openButton.isDown))
        {
            effectExplosion.SetActive(true);
            infoCanvas.enabled = false;
            removingWalls.SetActive(false);

        }
    }
}
