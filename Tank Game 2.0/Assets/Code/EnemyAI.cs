using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer, whatIsWall;

    //code from PlayerShooting
    public Rigidbody projectile;
    public Transform shootingObject;

    //Potroling 
    public Vector3 walkPoint, playerWalkPoint;
    public bool walkPointSet, playerWalkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //enemy patrols at call times unless player is in raycast
        Patroling();

        //chase player
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();


        Vector3 distanceToPlayerWalkPoint = transform.position - playerWalkPoint;

        if (distanceToPlayerWalkPoint.magnitude < 2f)
        {
            playerWalkPointSet = false;
        }

        //attack player
        Debug.DrawRay(transform.position, player.position - transform.position);

        if (!Physics.Raycast(transform.position, player.position - transform.position, sightRange, whatIsWall))
        {
            if (playerInSightRange && playerInAttackRange) AttackPlayer();

        }
    }

    private void Patroling()
    {
        if (!playerWalkPointSet)
            {
                if (!walkPointSet) SeachWalkPoint();

                if (walkPointSet)
                    agent.SetDestination(walkPoint);

                Vector3 distanceToWalkPoint = transform.position - walkPoint;

                //Walkpoint reached 
                if (distanceToWalkPoint.magnitude < 3f)
                     walkPointSet = false;
             }
    }

    private void SeachWalkPoint()
    {
        //make random point in range 
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 10f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        Debug.DrawRay(transform.position, player.position - transform.position);

        if (!Physics.Raycast(transform.position, player.position - transform.position,sightRange, whatIsWall))
        {
            playerWalkPoint = new Vector3(player.position.x, player.position.y, player.position.z);

            playerWalkPointSet = true;
            agent.SetDestination(player.position);

        }

    }

    private void AttackPlayer() 
    {
        
        //agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //attack code here
            Instantiate(projectile, shootingObject.position, shootingObject.rotation);
            //sound
            FindObjectOfType<audioManager>().Play("shooting");

            //time between attacks 

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    //This code is ran when the object hits a collider
    private void OnTriggerEnter(Collider other)
    {
        //Destroys the object after hitting a Collider
        Destroy(gameObject);

    }
}
