using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolowing : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;    //найти через скрипт
    [SerializeField] private float cameraSpeed;
    public float cameraMaxHeight;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    void FixedUpdate()
    {
        Vector3 target = playerTransform.position + offset;
        float delta = cameraMaxHeight - target.y;
        if (delta < 0) target = new Vector3(target.x, cameraMaxHeight, target.z);
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * cameraSpeed);
        //transform.position = playerTransform.position + offset;
    }

    public void ShakeCamera()
    {

    }
}
