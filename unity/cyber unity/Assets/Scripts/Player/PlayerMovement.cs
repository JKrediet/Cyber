using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 10f;

    public float turnSmoothTime = 0.1f;
    public float gravity = -1f;
    float turnSmoothVelocity;
    public bool isAiming = false, isAttacking = false;

    private float horizontal, vertical;
    public Mc mc;
    public Animator anim;
    public bool menuActive;

    void Update()
    {
        if(isAiming == false)
        {
            if (isAttacking == false)
            {
                if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
                {
                    StartWalkAnim();
                }
                else
                {
                    if(menuActive == true)
                    {
                        MenuToActive();
                    }
                    else
                    {
                        MenuToFlase();
                        StartIdleAnim();
                    }
                }
                horizontal = Input.GetAxisRaw("Horizontal");
                vertical = Input.GetAxisRaw("Vertical");
            }
        }
        if (Input.GetButton("Fire1"))
        {
            if(isAttacking == false)
            {
                StartAtackSword1Anim();
                isAttacking = true;
                Invoke("StopAllAnim", 0.7f);
                Invoke("IsAttacking", 0.7f);
            }
        }
        if (Input.GetButton("Fire2"))
        {
            transform.forward = new Vector3(cam.forward.x, transform.forward.y, cam.forward.z);
            StartBowAimAnim();
        }
        if (Input.GetButtonUp("Fire2"))
        {
            StopAllAnim();
            StartBowreleaseAnim();
        }


        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDir.y -= gravity * Time.deltaTime;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        if (Input.GetButton("Fire2") || Input.GetButton("Fire1"))
        {
            isAiming = true;
            horizontal = 0;
            vertical = 0;
        }
        else
        {
            isAiming = false;
        }
    }
    public void MenuToActive()
    {
        StopAllAnim();
        anim.SetBool("menu", true);
    }
    public void MenuToFlase()
    {
        StopAllAnim();
        anim.SetBool("menu", false);
    }

    public void IsAttacking()
    {
        isAttacking = false;
    }
    public void StartIdleAnim()
    {
        StopAllAnim();
        anim.SetBool("IsIdleing", true);
    }
    public void StartWalkAnim()
    {
        mc.arrowb = false;
        mc.bowb = false;
        mc.bowsinb = false;
        mc.swordb = false;  
        StopAllAnim();
        anim.SetBool("IsWalking", true);
    }
    public void StartAtackSword1Anim()
    {
        StopAllAnim();
        mc.swordb = true;
        mc.arrowb = false;
        mc.bowb = false;
        mc.bowsinb = false;
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            anim.SetBool("IsAtackingSword1", true);
        }
        else if (random == 1)
        {
            anim.SetBool("IsAtackingSword2", true);
        }
    }
    public void StartBowAimAnim()
    {
        StopAllAnim();
        mc.swordb = false;
        mc.arrowb = true;
        mc.bowb = true;
        mc.bowsinb = true;
        anim.SetBool("IsBowAiming", true);
    }
    public void StartBowreleaseAnim()
    {
        StopAllAnim();
        mc.bowsinb = false;
        anim.SetBool("IsBowRealesing", true);
    }
    public void StopAllAnim()
    {
        anim.SetBool("IsBowRealesing", false);
        anim.SetBool("IsBowAiming", false);
        anim.SetBool("IsAtackingSword2", false);
        anim.SetBool("IsAtackingSword1", false);
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsIdleing", false);
    }
}
