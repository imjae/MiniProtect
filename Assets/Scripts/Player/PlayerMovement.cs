using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform mainCamera;

    void Start()
    {
        mainCamera = Camera.main.gameObject.transform;

        Debug.Log(transform.TransformDirection(mainCamera.forward));
        Debug.Log(transform.TransformDirection(mainCamera.right));

    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
    }

    public void InputMovement(Rigidbody rigid, float moveSpeed)
    {
        Vector3 forward = mainCamera.forward;
        Vector3 right = mainCamera.right;

        Vector3 moveDirection =
                    forward * Input.GetAxisRaw("Vertical") +
                    right * Input.GetAxisRaw("Horizontal");

        // Debug.Log(moveDirection);

        rigid.velocity = moveDirection.normalized * moveSpeed;

        // transform.position = moveDirection.normalized * Time.deltaTime * moveSpeed;

        // transform.Translate(transform.position + (moveDirection.normalized * moveSpeed));
    }

    public void InputJump(Rigidbody rigid, float jumpPower, bool isGround)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("มกวม");
            rigid.AddForce(Vector3.up * jumpPower);
        }
            
    }
}
