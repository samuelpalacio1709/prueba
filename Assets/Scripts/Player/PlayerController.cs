using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    [SerializeField] float movementSpeed = 5f;
    private Vector2 inputDirection;

    private void Awake()
    {
        playerRigidbody= GetComponent<Rigidbody2D>();
        playerRigidbody.gravityScale = 0;
        InputHandler.OnInputMovement += ChangePlayerDirection;
    }
    private void OnDisable()
    {
        InputHandler.OnInputMovement -= ChangePlayerDirection;
    }
    private void Update()
    {
        Vector3 movement = inputDirection * movementSpeed;
        playerRigidbody.velocity = movement;
    }

    private void ChangePlayerDirection(Vector2 direction)
    {
        inputDirection = direction;
    }
}
