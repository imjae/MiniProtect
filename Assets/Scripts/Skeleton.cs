using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        if (!TryGetComponent<NavMeshAgent>(out monsterAI))
            Debug.LogError($"{name} : NavMeshAgent 컴포넌트 없음");


        Tracking();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Attack()
    {
        base.Attack();
        Debug.Log("슬라임 : 몸통박치기!");

    }

    protected override void Die()
    {
        base.Die();
        Debug.Log("슬라임 : 죽음!");

    }
}
