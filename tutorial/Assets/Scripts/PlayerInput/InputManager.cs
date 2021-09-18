using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // Events
    public static UnityEvent<Vector3> PlayerMove = new UnityEvent<Vector3>();
    public static UnityEvent<Vector2> PlayerLook = new UnityEvent<Vector2>();
    
    public static UnityEvent PlayerJump = new UnityEvent();
    public static UnityEvent PlayerFire = new UnityEvent();

    // Player Controls
    PlayerInput playerInput;

    void Awake() {
        playerInput = new PlayerInput();
    }

    private void OnEnable() {
        playerInput.Player.Enable();
    }

    private void OnDisable() {
        playerInput.Player.Disable();
    }

//! ----------------------------------------------------- Player Movement

    private void OnMove(InputValue input) {
        Vector2 inputVector = input.Get<Vector2>();
        Vector3 moveVector = new Vector3(inputVector[0], 0, inputVector[1]);
        PlayerMove.Invoke(moveVector);
    }

    private void OnLook(InputValue input) {
        Vector2 inputVector = input.Get<Vector2>();
        PlayerLook.Invoke(inputVector);
    }

    private void OnJump() {
        PlayerJump.Invoke();
    }

    private void OnFire() {
        PlayerFire.Invoke();
    }

}
