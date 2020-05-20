using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{ 
    public Transform tr;

    float xRotation = 0f;
    float zRotation = 0f;
    public float mouseSensitivity = 100f;

    public PlayerMovement playerMovement;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        zRotation = Mathf.Clamp(zRotation, -5f, 5f);
        transform.localRotation = Quaternion.Euler(zRotation, 0f, playerMovement.angle);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, playerMovement.angle);
        tr.Rotate(Vector3.up * mouseX);


    }
}
