using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public void InputMovement(Rigidbody rigid, float moveSpeed)
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        Vector3 moveDirection =
                    forward * Input.GetAxisRaw("Vertical") +
                    right * Input.GetAxisRaw("Horizontal");

        rigid.velocity = moveDirection.normalized * moveSpeed;

        // transform.Translate(transform.position + (moveDirection.normalized * moveSpeed));
    }

    public void InputJump(Rigidbody rigid, float jumpPower, bool isGround)
    {
        if (Input.GetKeyDown(KeyCode.Space))
            rigid.AddForce(Vector3.up * jumpPower);
    }
}
