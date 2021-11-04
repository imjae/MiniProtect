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
        // ���� �⺻ Attack ����
        throw new System.NotImplementedException();
    }
    protected override void Die()
    {
        // ���� �⺻ Die ����
        throw new System.NotImplementedException();
    }
}
