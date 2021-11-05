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
            Debug.LogError("PlayerMovement ��ũ��Ʈ ������Ʈ ����");
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
        // ���� �⺻ Die ����
        throw new System.NotImplementedException();
    }
}
