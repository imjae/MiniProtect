using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    PlayerMovement movementScript;
    PlayerRotation rotationScript;
    Rigidbody rigid;

    float jumpPower;

    bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        MoveSpeed = 10f;
        jumpPower = 500f;
        isGround = true;

        if (!TryGetComponent<PlayerMovement>(out movementScript))
            Debug.LogError("PlayerMovement 스크립트 컴포넌트 없음");
        if (!TryGetComponent<PlayerRotation>(out rotationScript))
            Debug.LogError("PlayerRotation 스크립트 컴포넌트 없음");
        if (!TryGetComponent<Rigidbody>(out rigid))
            Debug.LogError("Rigidbody 컴포넌트 없음");
    }

    // Update is called once per frame
    void Update()
    {
        rotationScript.InputRotation();
        

        Attack();
    }

    void FixedUpdate()
    {
        movementScript.InputMovement(rigid, MoveSpeed);
        movementScript.InputJump(rigid, jumpPower, isGround);
    }

    protected override void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {

        }
    }
    protected override void Die()
    {
        // 몬스터 기본 Die 동작
        throw new System.NotImplementedException();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            Debug.Log(isGround);
            isGround = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            Debug.Log(isGround);
            isGround = false;
        }
    }
}
