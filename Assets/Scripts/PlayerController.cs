using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float sprintSpeedMultiplier = 2.0f;
    public float crouchSpeedMultiplier = 0.5f;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private bool isCrouching = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            float moveSpeed = speed;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed *= sprintSpeedMultiplier;
            }

            if (Input.GetKey(KeyCode.C))
            {
                isCrouching = true;
                moveSpeed *= crouchSpeedMultiplier;
            }
            else
            {
                isCrouching = false;
            }

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
