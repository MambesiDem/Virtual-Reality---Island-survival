using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private float lookSpeed = 50f;
    [SerializeField] private float minPitch = -60f;
    [SerializeField] private float maxPitch = 60f;

    private InputAction lookAction;
    private float pitch = 0f;

    void Start()
    {
        var gameplayMap = inputActions.FindActionMap("Gameplay", true);
        lookAction = gameplayMap.FindAction("Look", true);
        lookAction.Enable();
    }

    void Update()
    {
        Vector2 lookInput = lookAction.ReadValue<Vector2>();
        pitch -= lookInput.y * lookSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    private void OnDestroy()
    {
        lookAction.Disable();
    }
}