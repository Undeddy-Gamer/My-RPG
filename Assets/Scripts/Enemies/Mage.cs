using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Enemey
{
    [Header("Mage Stats")]
    public float curMana;
    public float maxMana;
    public float manaRegen;
    
        
    
    public void FireBallAttack()
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
        Debug.Log("Fireball Attack");
        
    }
    
}
