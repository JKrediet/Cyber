using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    private Vector3 movementDirection;
    public float movementSpeed, gravity;

    // forward controls
    public Transform cameraRotation;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            movementDirection *= movementSpeed;
            movementDirection = transform.TransformDirection(movementDirection);
        }
        movementDirection.y -= gravity * Time.deltaTime;
        characterController.Move(movementDirection * Time.deltaTime);

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            transform.forward = new Vector3(cameraRotation.transform.forward.x, transform.forward.y, cameraRotation.transform.forward.z);
        }
    }
}