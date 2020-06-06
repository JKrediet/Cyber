using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemieScript : MonoBehaviour
{
    [Header("variables enemie")]
    public Vector3 playerPosition, enemiePos;
    RaycastHit hit;
    public Animator anim;
    public Transform player;
    public bool hitplayer, isAtacking, playerInRange, doingIdle, walking, isBoss, isFinalBoss;
    public int idleNumber;
    public float healtStatus, enemieDamage, attackRange, enemieSpeed;
    public GameObject elevator, rune;
    private void Start()
    {
        StartCoroutine(StartIdleAnim());
        hitplayer = false;
        isAtacking = false;
        GetComponent<NavMeshAgent>().speed = enemieSpeed;
    }
    void Update()
    {
        HealthUpdate();
        Detact();
        EnemieMovement();
    }
    public void HealthUpdate()
    {
        healtStatus = GetComponent<HealthTestEnemy>().health;
        if (healtStatus <= 0)
        {
            StartCoroutine(Death());
        }
    }
    IEnumerator Death()
    {
        GetComponent<NavMeshAgent>().speed = 0;
        StartDeathAnim();
        if (isBoss == true)
        {
            elevator.GetComponent<Elevator>().DeadBoss = true;
        }
        if (isFinalBoss == true)
        {
            rune.SetActive(true);
        }
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    public void Detact()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
        {
            if (hit.transform.tag == "Player")
            {
                if (player)
                {
                    Vector3 forward = transform.TransformDirection(Vector3.forward);
                    Vector3 toOther = player.position - transform.position;
                    if (Vector3.Dot(forward, toOther) < 0)
                    {

                        hitplayer = false;
                    }
                    if (Vector3.Dot(forward, toOther) > 0)
                    {

                        if (isAtacking == false)
                        {
                            print("5");
                            StartCoroutine(Atack());
                        }
                    }
                }
            }
        }
    }
    IEnumerator Atack()
    {
        walking = false;
        isAtacking = true;
        GetComponent<NavMeshAgent>().speed = 0;
        StartAtackAnim();
        player.GetComponent<Health>().DoDamage(enemieDamage);
        print("dodamgae");
        yield return new WaitForSeconds(3);
        print("loop");
        GetComponent<NavMeshAgent>().speed = enemieSpeed;
        StartWalkAnim();
        isAtacking = false;
        walking = true;
    }
    public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.transform.tag == "Player")
        {
            playerInRange = true;
            walking = true;
        }
    }
    public void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.transform.tag == "Player")
        {
            playerInRange = false;
            walking = false;
        }
    }
    public void EnemieMovement()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        enemiePos = transform.position;
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (playerInRange == true)
        {
            if (walking == true)
            {
                StartWalkAnim();
            }
            agent.destination = playerPosition;
            doingIdle = false;
        }
        else
        {
            if (doingIdle == false)
            {
                agent.destination = enemiePos;
                StartCoroutine(StartIdleAnim());
            }
        }
        if (isAtacking == true)
        {
            agent.destination = enemiePos;
        }
    }
    IEnumerator StartIdleAnim()
    {
        doingIdle = true;
        yield return new WaitForSeconds(0.01f);
        StopAllAnim();
        int random = Random.Range(0, 3);
        if (random == 0)
        {
            anim.SetBool("IsIdle1", true);
        }
        else if (random == 1)
        {
            anim.SetBool("IsIdle2", true);
        }
        else if (random == 2)
        {
            anim.SetBool("IsIdle3", true);
        }
    }
    public void StartWalkAnim()
    {
        StopAllAnim();
        anim.SetBool("IsWalking", true);
    }
    public void StartAtackAnim()
    {
        StopAllAnim();
        anim.SetBool("IsAtacking", true);
    }
    public void StartDeathAnim()
    {
        StopAllAnim();
        anim.SetBool("IsDeath", true);
    }
    public void StopAllAnim()
    {
        anim.SetBool("IsIdle1", false);
        anim.SetBool("IsIdle2", false);
        anim.SetBool("IsIdle3", false);
        anim.SetBool("IsAtacking", false);
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsDeath", false); ;
    }
}