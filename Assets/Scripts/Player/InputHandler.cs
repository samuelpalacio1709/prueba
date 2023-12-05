using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour
{
    private PlayerInput input;
    public static Action<Vector2> OnInputMovement;
    public static Action OnInputInteraction;
    private void Awake()
    {
        input = new PlayerInput();
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += HandleInputMovementPerformed;
        input.Player.Movement.canceled += HandleInputMovementCanceled;
        input.Player.Interact.performed += HandleInputInteractionPerformed;

    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= HandleInputMovementPerformed;
        input.Player.Movement.canceled -= HandleInputMovementCanceled;
        input.Player.Interact.performed -= HandleInputInteractionPerformed;

    }

    private void HandleInputMovementPerformed(InputAction.CallbackContext context)
    {
        OnInputMovement?.Invoke(context.ReadValue<Vector2>());
    }
    private void HandleInputMovementCanceled(InputAction.CallbackContext context)
    {
        OnInputMovement?.Invoke(Vector2.zero);
    }
    private void HandleInputInteractionPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Interaction");
        OnInputInteraction?.Invoke();
    }



}
