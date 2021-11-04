using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    float clampAngle;
    float sensitivity;

    float rotX;
    float rotY;
    // Start is called before the first frame update
    void Start()
    {
        sensitivity = 500f;
        clampAngle = 35f;
    }

    // Update is called once per frame
    void Update()
    {
        // 카메라의 회전
        rotX += -(Input.GetAxis("Mouse Y")) * sensitivity * Time.deltaTime;
        rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
        transform.rotation = rot;
    }
}
