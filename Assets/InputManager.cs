using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInputs playerInputs;
    private PlayerInputs.GroundMovementActions input;

    private Player movement;
    private PlayerCamera look;

    void Awake()
    {
        playerInputs = new PlayerInputs();
        input = playerInputs.GroundMovement;
        movement = GetComponent<Player>();
        look = GetComponent<PlayerCamera>();
    }


    void FixedUpdate()
    {
        //Tell the play movement to move using the value from our movement action
        movement.ProcessMove(input.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(input.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
