using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemey
{
    [Header("Skeleton Stats")]
    // the amount of decay of the skeleton which effects movement speed and attack
    public int amountDecayed = 10;


    private void Start()
    {
        // get random decay amount on spawn
        amountDecayed = UnityEngine.Random.Range(0, 21);
    }

    public override void Attack()
    {

        //change speed depending on decay amount
        this.moveSpeed = amountDecayed * 0.3f;
        
    }

    public void SwordAttack()
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
        player.GetComponent<PlayerHandler>().DamagePlayer(baseDamage * difficulty + critDamage - amountDecayed);

        // log a test check for polymorphism
        Debug.Log("Sword Attack");
        
    }
    
}
