using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragon : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        if (!TryGetComponent<NavMeshAgent>(out monsterAI))
            Debug.LogError($"{name} : NavMeshAgent ÄÄÆ÷³ÍÆ® ¾øÀ½");


        Tracking();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Attack()
    {
        base.Attack();
        Debug.Log("µå·¡°ï : È­¿° °ø°Ý!");

    }
    
    protected override void Die()
    {
        base.Die();
        Debug.Log("µå·¡°ï : Á×À½!");
        
    }
}
