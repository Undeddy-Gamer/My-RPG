using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemey
{
    [Header("Wolf Stats")]
    public float curStamina;
    public float maxStamina;

    public override void Attack()
    {
        Debug.Log("Action 1");

        base.Attack();

        Debug.Log("Action 2");
    }
}
