using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    [Header("Movement Parameter")]
    private float speed = 10f;

    [Header("Jumping Parameters")]
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;

    [Header("Conditional Parameters")]
    private bool isGrounded;
    public bool running = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.height = 3;
    }

    //Receives inputs from Input Manager & apply to character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        controller.Move(speed * Time.deltaTime * transform.TransformDirection(moveDirection));
        playerVelocity.y += gravity * Time.deltaTime;

        //Stops player from sliding 
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        controller.Move(playerVelocity * Time.deltaTime);
    }
}
