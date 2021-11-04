using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Monster : Character
{
    protected NavMeshAgent monsterAI;

    protected virtual void Tracking()
    {
        monsterAI.SetDestination(GameManager.Instance.player.transform.position);
    }

    protected override void Attack()
    {
        // 몬스터 기본 Attack 동작
        throw new System.NotImplementedException();
    }
    protected override void Die()
    {
        // 몬스터 기본 Die 동작
        throw new System.NotImplementedException();
    }
}
