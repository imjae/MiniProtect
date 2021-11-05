using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    PlayerMovement movementScript;
    Rigidbody rigid;

    public float jumpPower;

    bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        MoveSpeed = 10f;
        jumpPower = 500f;
        isGround = true;

        if (!TryGetComponent<PlayerMovement>(out movementScript))
            Debug.LogError("PlayerMovement 스크립트 컴포넌트 없음");
        if (!TryGetComponent<Rigidbody>(out rigid))
            Debug.LogError("Rigidbody 컴포넌트 없음");
    }

    // Update is called once per frame
    void Update()
    {
        // rotationScript.InputRotation();
        

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




    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("collision" + isGround);
            isGround = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("collision" + isGround);
            isGround = false;
        }
    }

}
