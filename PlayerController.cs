//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    [Header("Movement Settings")]
//    public float speed = 5f;
//    public float rotationSpeed = 120f;

//    [Header("Pickup Settings")]
//    public float pickupRange = 5f; // Distance player can reach to pick up items

//    private Rigidbody rb;
//    private Animator animator;
//    private Camera playerCamera;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        animator = GetComponent<Animator>();
//        playerCamera = GetComponentInChildren<Camera>();
//    }

//    void FixedUpdate()
//    {
//        HandleMovement();
//    }

//    void Update()
//    {
//        HandlePickup();
//    }

//    // Handle movement and rotation
//    void HandleMovement()
//    {
//        float moveVertical = Input.GetAxis("Vertical");   // Joystick forward/back
//        float moveHorizontal = Input.GetAxis("Horizontal"); // Joystick left/right

//        // Move player
//        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
//        rb.MovePosition(rb.position + movement);

//        // Rotate player
//        float turn = moveHorizontal * rotationSpeed * Time.fixedDeltaTime;
//        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
//        rb.MoveRotation(rb.rotation * turnRotation);

//        // Animate walking/running
//        float currentSpeed = new Vector3(moveHorizontal, 0f, moveVertical).magnitude;
//        animator.SetFloat("Speed", currentSpeed, 0.1f, Time.deltaTime);
//    }

//    // Handle picking up items in front of the player
//    void HandlePickup()
//    {
//        if (Input.GetButtonDown("Fire1"))
//        {
//            // Cast ray from the player's chest height forward
//            Ray ray = new Ray(transform.position + Vector3.up * 1f, transform.forward);
//            RaycastHit hit;

//            // Debug ray in Scene view
//            Debug.DrawRay(ray.origin, ray.direction * pickupRange, Color.red, 2f);

//            if (Physics.Raycast(ray, out hit, pickupRange))
//            {
//                Debug.Log($"Raycast hit: {hit.collider.name}, Tag: {hit.collider.tag}");

//                // Check if object has Interactable script (PickupItem, Firepit, etc.)
//                Interactable interactable = hit.collider.GetComponent<Interactable>();
//                if (interactable != null)
//                {
//                    Debug.Log($"Interacting with: {hit.collider.name}");
//                    interactable.OnInteract(); // Will call PickupItem.OnInteract or Firepit.OnInteract
//                }
//                else
//                {
//                    Debug.Log("Hit object is not interactable.");
//                }
//            }
//            else
//            {
//                Debug.Log("Raycast did not hit anything.");
//            }
//        }
//    }
//}
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class PlayerController : MonoBehaviour
//{
//    [Header("Movement Settings")]
//    public float speed = 5f;

//    private Rigidbody rb;
//    private Animator animator;
//    private Camera playerCamera;

//    private Vector2 moveInput;

//    private PlayerControls controls;

//    void Awake()
//    {
//        rb = GetComponent<Rigidbody>();
//        animator = GetComponent<Animator>();
//        playerCamera = GetComponentInChildren<Camera>();

//        // Setup new Input System
//        controls = new PlayerControls();
//        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
//        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
//    }

//    void OnEnable() => controls.Enable();
//    void OnDisable() => controls.Disable();

//    void FixedUpdate()
//    {
//        HandleMovement();
//    }

//    void HandleMovement()
//    {
//        // Move in the direction of the joystick relative to player orientation
//        Vector3 move = transform.forward * moveInput.y + transform.right * moveInput.x;
//        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);

//        // Animate movement
//        animator.SetFloat("Speed", move.magnitude, 0.1f, Time.deltaTime);

//        // Rotate player to match VR camera Y rotation (head direction)
//        Vector3 euler = transform.eulerAngles;
//        euler.y = playerCamera.transform.eulerAngles.y;
//        transform.eulerAngles = euler;
//    }
//}
//using UnityEngine;
//using UnityEngine.InputSystem;

//[RequireComponent(typeof(Rigidbody))]
//public class PlayerController : MonoBehaviour
//{
//    public PlayerInputWrapper inputWrapper;

//    [Header("Movement Settings")]
//    public float speed = 5f;
//    public float rotationSpeed = 120f;

//    [Header("Interaction Settings")]
//    public float interactRange = 3f;
//    public InputActionProperty moveAction;     // Vector2 (WASD/joystick)
//    public InputActionProperty interactAction; // Button (A / trigger)

//    private Rigidbody rb;
//    private Animator animator;
//    private Camera playerCamera;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        animator = GetComponent<Animator>();
//        playerCamera = Camera.main;

//        if (moveAction != null) moveAction.action.Enable();
//        if (interactAction != null) interactAction.action.Enable();
//    }

//    void FixedUpdate()
//    {
//        HandleMovement();
//    }

//    void Update()
//    {
//        HandleInteraction();
//    }

//    void HandleMovement()
//    {
//        if (moveAction == null || moveAction.action == null) return;

//        Vector2 input = moveAction.action.ReadValue<Vector2>();

//        // Move forward/back
//        Vector3 movement = transform.forward * input.y * speed * Time.fixedDeltaTime;
//        rb.MovePosition(rb.position + movement);

//        // Rotate left/right
//        float turn = input.x * rotationSpeed * Time.fixedDeltaTime;
//        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turn, 0f));

//        // Animate
//        float currentSpeed = input.magnitude;
//        if (animator != null)
//            animator.SetFloat("Speed", currentSpeed, 0.1f, Time.deltaTime);
//    }

//    void HandleInteraction()
//    {
//        if (interactAction == null || interactAction.action == null) return;

//        if (interactAction.action.WasPerformedThisFrame())
//        {
//            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
//            if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
//            {
//                var interactable = hit.collider.GetComponent<Interactable>();
//                if (interactable != null)
//                {
//                    interactable.OnInteract();
//                }
//            }
//        }
//    }

//    private void OnDestroy()
//    {
//        if (moveAction != null) moveAction.action.Disable();
//        if (interactAction != null) interactAction.action.Disable();
//    }
//}
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


