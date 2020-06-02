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
    public bool isAiming = false;

    private float horizontal, vertical;

    void Update()
    {
        if(isAiming == false)
        {
             horizontal = Input.GetAxisRaw("Horizontal");
             vertical = Input.GetAxisRaw("Vertical");
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
            transform.forward = new Vector3(cam.forward.x, transform.forward.y, cam.forward.z);
            isAiming = true;
            horizontal = 0;
            vertical = 0;
        }
        else
        {
            isAiming = false;
        }
    }
}
