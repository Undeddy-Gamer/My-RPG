using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine;

public class Enemey : MonoBehaviour
{
    public enum AIState
    {
        Patrol,
        Seek,
        Attack,
        Die
    }

    [Space(5), Header("Base Stats")]
    public float curHealth;
    public float maxHealth, moveSpeed, attackRange, attackSpeed, sightRange, baseDamage;
    public int curWaypoint;
    public int difficulty;

    [Space(5), Header("Base References")]
    public GameObject self;
    public Transform waypointParent;
    protected Transform[] waypoints;
    public NavMeshAgent agent;
    public GameObject healthCanvas;
    public Image healthBar;
    public Transform player;
    public Animator anim;
    public AIState state;

    private void Start()
    {
        //get the waypoints
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        //get the nav mesh 
        agent = self.GetComponent<NavMeshAgent>();
        //start initial patrol
        Patrol();

        agent.speed = moveSpeed;
        anim = self.GetComponent<Animator>();

        curWaypoint = 1;
    }


    public void Patrol()
    {
        // If no waypoints set do not continue
        if(waypoints.Length == 0 || Vector3.Distance(player.position, self.transform.position) <= sightRange || curHealth < 0)
        {
            return;
        }

        state = AIState.Patrol;
        //follow way points
        //Set agent to target
        agent.destination = waypoints[curWaypoint].position;
        //are we at the waypoint
        if(self.transform.position.x.Equals(agent.destination.x) && self.transform.position.z.Equals(agent.destination.z))
        {
            if(curWaypoint < waypoints.Length-1)
            {
                //if so go to next waypoint
                curWaypoint++;
            }
            else
            {
                //if at end of partrol go to start
                curWaypoint = 0;
            }

        }
        anim.SetBool("Walk", true);       

    }


    private void Update()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);

        Patrol();
        Seek();
        Attack();
        Die();
    }

    public void Seek()
    {
        //If player in sight range chase
        if (Vector3.Distance(player.position, self.transform.position) > sightRange || Vector3.Distance(player.position, self.transform.position) < attackRange || curHealth < 0)
        {
            return;
        }
        state = AIState.Seek;
        anim.SetBool("Run", true);
        agent.destination = player.position;
    }

    public virtual void Attack()
    {
        //if player in attack range attack
                
        if(Vector3.Distance(player.position, self.transform.position) >= attackRange || curHealth < 0 || player.GetComponent<PlayerHandler>().curHealth < 0)
        {
            return;
        }

        state = AIState.Attack;
        anim.SetTrigger("Attack");
        Debug.Log("Attack");


    }

    public void Die()
    {
        //if enemy <= 0 health death occurs
        if (curHealth > 0)
        {
            return;
        }
        //else we are dead so run this
        state = AIState.Die;
        agent.destination = self.transform.position;

        anim.SetTrigger("Die");
    }


}

