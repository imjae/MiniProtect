using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 500f;
    public Transform playerBody;
    float xRotation = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * (mouseSensitivity);
        float mouseY = Input.GetAxis("Mouse Y") * (mouseSensitivity);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Vector3.Slerp(,)

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
