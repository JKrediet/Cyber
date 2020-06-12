using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class EnemieScript : MonoBehaviour
{
    [Header("variables enemie")]
    public Vector3 playerPosition, enemiePos, enemyHit;
    RaycastHit hit;
    public Animator anim;
    public Transform player;
    public bool hitplayer, isAtacking, playerInRange, doingIdle, walking, isBoss, isFinalBoss,isDeath, walkingSoundEffect, deathSoundEffect;
    public int idleNumber;
    public float healtStatus, enemieDamage, attackRange, enemieSpeed;
    public GameObject elevator, rune;
    [Header("sounds enemie")]
    public GameObject walking_Sound, atacking_Sound, death_Sound, idle_Sound,mcHit_sound;
    private void Start()
    {
        StartCoroutine(StartIdleAnim());
        hitplayer = false;
        isAtacking = false;
        GetComponent<NavMeshAgent>().speed = enemieSpeed;
        isDeath = false;
        if(isBoss == true)
        {
            enemyHit = new Vector3(0, 1.5f, 0);
        }
        else
        {
            enemyHit = new Vector3(0, 1, 0);
        }
    }
    void Update()
    {
        HealthUpdate();
        Detact();
        EnemieMovement();
        Test();
        if (isDeath == true)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            if (deathSoundEffect == false)
            {
                idle_Sound.GetComponent<AudioSource>().Stop();
                mcHit_sound.GetComponent<AudioSource>().Stop();
                atacking_Sound.GetComponent<AudioSource>().Stop();
                walking_Sound.GetComponent<AudioSource>().Stop();
                death_Sound.GetComponent<AudioSource>().Play();
                deathSoundEffect = true;
            }
        }
    }
    public void HealthUpdate()
    {
        healtStatus = GetComponent<HealthTestEnemy>().health;
        if (healtStatus <= 0)
        {
            isDeath = true;
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
        if (isDeath == false)
        {
            if (Physics.Raycast(transform.position - enemyHit, transform.forward, out hit, attackRange))
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
                                StartCoroutine(Atack());
                            }
                        }
                    }
                }
            }
        }
    }

    IEnumerator Atack()
    {
        if (isDeath == false)
        {
        walking = false;
        isAtacking = true;
        GetComponent<NavMeshAgent>().speed = 0;
        StartAtackAnim();
        Invoke("DoDamage", (1));
        yield return new WaitForSeconds(3);
        GetComponent<NavMeshAgent>().speed = enemieSpeed;
        StartWalkAnim();
        isAtacking = false;
        walking = true;
        }
    }
    public void DoDamage()
    {
        if (isDeath == false)
        {
        
             Vector3 forward = transform.TransformDirection(Vector3.forward);
             Vector3 toOther = player.position - transform.position;
            if (Vector3.Dot(forward, toOther) > 0)
              {
                 player.gameObject.GetComponent<HealthPlayer>().Health(enemieDamage);
                 mcHit_sound.GetComponent<AudioSource>().Play();
                 player.gameObject.GetComponent<AudioMC>().GettingHit();
              }
        }
    }
   
    public void EnemieMovement()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        enemiePos = transform.position;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (playerInRange == true)
        {
            if (walking == true)
            {
                if (isDeath == false)
                {
                    StartWalkAnim();
                }
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
        walkingSoundEffect = false;
        walking_Sound.GetComponent<AudioSource>().Stop();
        if (isDeath == false)
        {
            idle_Sound.GetComponent<AudioSource>().Play();
        }
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
        if (walkingSoundEffect == false)
        {
              idle_Sound.GetComponent<AudioSource>().Stop();
            if (isDeath == false)
            {
                walking_Sound.GetComponent<AudioSource>().Play();
            }
            walkingSoundEffect = true;
        }
        anim.SetBool("IsWalking", true);
    }
    public void StartAtackAnim()
    {
        StopAllAnim();
        walkingSoundEffect = false;
        walking_Sound.GetComponent<AudioSource>().Stop();
        idle_Sound.GetComponent<AudioSource>().Stop();
        if (isDeath == false)
        {
            atacking_Sound.GetComponent<AudioSource>().Play();
        }
        anim.SetBool("IsAtacking", true);
    }
    public void StartDeathAnim()
    {
        walkingSoundEffect = true;
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
        atacking_Sound.GetComponent<AudioSource>().Stop();
        mcHit_sound.GetComponent<AudioSource>().Stop();
        
    }
    public void StopAllSound()
    {
        atacking_Sound.GetComponent<AudioSource>().Stop();
        mcHit_sound.GetComponent<AudioSource>().Stop();
        walking_Sound.GetComponent<AudioSource>().Stop();
        idle_Sound.GetComponent<AudioSource>().Stop();
        death_Sound.GetComponent<AudioSource>().Stop();
    }
    public void Test()
    {
        Debug.DrawRay(transform.position - enemyHit, transform.forward, Color.red);
    }
}