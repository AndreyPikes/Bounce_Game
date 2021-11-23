using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCameraTrigger : MonoBehaviour
{
    [SerializeField] CameraFolowing cam;
    [SerializeField] float newMaxHeight;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cam.cameraMaxHeight = newMaxHeight;
        }
    }
}
