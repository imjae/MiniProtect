using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;


    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void InputMovement(Rigidbody rigid, float moveSpeed)
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * z + transform.right * x;

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
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
