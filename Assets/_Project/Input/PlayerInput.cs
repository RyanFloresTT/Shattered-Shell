using System;
using UnityEngine;

public class PlayerInput : MonoSingleton<PlayerInput> {

    PlayerInputActions inputActions;
    public Action OnShoot;

    public Vector2 MoveDirection { get {
            return inputActions.Player.Move.ReadValue<Vector2>();    
    } }

    void Awake() {
        inputActions = new();
    }

    private void Start() {
        inputActions.Player.Shoot.performed += Shoot_performed;
    }

    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnShoot?.Invoke();
    }

    void OnEnable() {
        inputActions.Player.Move.Enable();
    }

    void OnDisable() {
        inputActions.Player.Move.Disable();
    }
}
