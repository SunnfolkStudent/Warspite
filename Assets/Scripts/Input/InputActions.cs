using UnityEngine;

public class InputActions : MonoBehaviour
{
    private InputSystem_Actions _inputSystem;

    public float Horizontal; // More to come
    public bool Jump; // More to come
    public bool Shoot;

    private void Update()
    {
        Horizontal = _inputSystem.Player.Move.ReadValue<Vector2>().x;
        Jump = _inputSystem.Player.Jump.WasPressedThisFrame();
        Shoot = _inputSystem.Player.Attack.WasPressedThisFrame();
    }

    private void Awake() { _inputSystem = new InputSystem_Actions(); }
    private void OnEnable() { _inputSystem.Enable(); }
    private void OnDisable() { _inputSystem.Disable(); }
}