using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private float _health;
    private float _moveSpeed;

    public float Health
    {
        get { return _health; }
        set { this._health = value; }
    }

    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { this._moveSpeed = value; }
    }


    protected abstract void Attack();
    protected abstract void Die();
}
