using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemey
{
    [Header("Wolf Stats")]
    public float curStamina;
    public float maxStamina;
    private float timer;
    public override void Attack()
    {

        //change speed periodically during attack run to simulate animal now running
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            this.moveSpeed = 7f;
            timer = 1;
                    }
        else if (timer > .5f)
        {
            this.moveSpeed = 5f;
        }
    }


    
    public void BiteAttack()
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
    
}
