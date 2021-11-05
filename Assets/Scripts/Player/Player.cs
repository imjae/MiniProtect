using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    PlayerMovement movementScript;

    // Start is called before the first frame update
    void Start()
    {
        MoveSpeed = 10f;

        if (!TryGetComponent<PlayerMovement>(out movementScript))
            Debug.LogError("PlayerMovement 스크립트 컴포넌트 없음");
    }

    // Update is called once per frame
    void Update()
    {

        Attack();
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
}
