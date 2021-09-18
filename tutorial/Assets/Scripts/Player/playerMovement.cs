using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{

    public float moveSpeed = 3.0f;
    public float maxSpeed = 10.0f;
    public float lookSpeed = 3.0f;
    public float jumpSpeed = 3.0f;
    private Rigidbody playerRb;
    private Vector3 moveVector;
    private Vector3 lookVector;
    private bool isGrounded = true;

    private bool userJumped;

    void Awake() {
        InputManager.PlayerMove.AddListener(SetMoveVector);
        InputManager.PlayerLook.AddListener(SetLookVector);
        InputManager.PlayerJump.AddListener(Jump);
        
        playerRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        HandleMovement();
    }

    private void SetMoveVector(Vector3 inputVector){
        this.moveVector = inputVector;
    }

    private void SetLookVector(Vector2 inputVector){
        lookVector = new Vector3(0, inputVector[0], 0);
    }

    private void HandleMovement(){
        
        Move();
        Rotate();
        //Jump();
    }

    private void Move() {
        // Fixed Movement
        // playerRb.transform.position += moveSpeed * moveVector * Time.deltaTime;

        // Velocity Movement
        if (PlatformManager.Instance.playerGrounded) {
            playerRb.velocity += moveVector * moveSpeed;

        }
    }

    private void Rotate() {
        Vector3 playerRot = playerRb.transform.rotation.eulerAngles;
        playerRot += lookVector * lookSpeed;
        playerRb.transform.rotation = Quaternion.Euler(playerRot);
    }

    private void SetGrounded(bool setting){
        this.isGrounded = setting;
    }

    private void Jump()
    {
        if (PlatformManager.Instance.playerGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
            this.SetGrounded(false);
        }
    }
}
