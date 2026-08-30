using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private InputSystem_Actions controls;
    public float rotationSpeed = 150f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controls = new InputSystem_Actions();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        controls.Player.Enable();
        Debug.Log(controls.Player.Move);
    }

    private void Update()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();

        float horizontalInput = moveInput.x; //Left and Right, Arrow keys

        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
