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
            Debug.LogError($"{name} : NavMeshAgent ??????Ʈ ????");


        Tracking();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Attack()
    {
        base.Attack();
        Debug.Log("?????? : ??????ġ??!");

    }

    protected override void Die()
    {
        base.Die();
        Debug.Log("?????? : ????!");

    }
}
