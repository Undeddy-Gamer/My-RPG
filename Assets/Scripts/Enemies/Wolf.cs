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
        // get a randomised crit chance
        int critChance = Random.Range(0, 21);
        float critDamage = 0;
        // if crit chance is hit (if it hits a 20 on a digital d20)
        if (critChance == 20)
        {
            //add Crit Damage
            critDamage = Random.Range(baseDamage / 2, baseDamage * difficulty);
        }

        // apply the damage to the player
        player.GetComponent<PlayerHandler>().DamagePlayer(baseDamage * difficulty + critDamage);

        // log a test check for polymorphism
        Debug.Log("Wolf Attack");

    }


    /*
    public void BiteAttack()
    {
        int critChance = Random.Range(0, 21);
        float critDamage = 0;
        if (critChance == 20)
        {
            critDamage = Random.Range(baseDamage / 2, baseDamage * difficulty);
        }

        player.GetComponent<PlayerHandler>().DamagePlayer(baseDamage * difficulty + critDamage);       
        
    }
    */
}
