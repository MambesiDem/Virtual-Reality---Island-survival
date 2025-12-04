using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;
    public float rotationSpeed = 120f;

    [Header("Interaction Settings")]
    public float interactRange = 10f; // Increased for testing
    [SerializeField] private Transform rayOrigin; // Optional override

    [Header("Input Settings")]
    [SerializeField] private InputActionAsset inputActions;

    private InputAction moveAction;
    private InputAction interactAction;

    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        var gameplayMap = inputActions.FindActionMap("Gameplay", true);
        moveAction = gameplayMap.FindAction("Move", true);
        interactAction = gameplayMap.FindAction("Interact", true);

        moveAction.Enable();
        interactAction.Enable();

        if (rayOrigin == null)
        {
            Debug.LogWarning("Ray Origin not assigned. Using default chest position.");
        }
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void Update()
    {
        //if (interactAction.ReadValue<float>() > 0)
        //{
        //    Debug.Log("Interact button is being pressed.");
        //}
        HandleInteraction();
    }

    void HandleMovement()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();

        Vector3 movement = transform.forward * input.y * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        float turn = input.x * rotationSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turn, 0f));

        if (animator != null)
            animator.SetFloat("Speed", input.magnitude, 0.1f, Time.deltaTime);
    }

    void HandleInteraction()
    {
        Vector3 origin = rayOrigin != null ? rayOrigin.position : transform.position + Vector3.up * 1.5f;
        Vector3 direction = rayOrigin != null ? rayOrigin.forward : transform.forward;

        Ray ray = new Ray(origin, direction);
        Debug.DrawRay(ray.origin, ray.direction * interactRange, Color.red, 1f);

        if (interactAction.WasPerformedThisFrame())
        {
            if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
            {
                Debug.Log("Raycast hit: " + hit.collider.name);
                var interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.OnInteract();
                }
                else
                {
                    Debug.Log("Hit object has no Interactable component.");
                }
            }
            else
            {
                Debug.Log("Raycast missed.");
            }
        }
    }

    private void OnDestroy()
    {
        moveAction.Disable();
        interactAction.Disable();
    }
}


