//using UnityEngine;

//public class Interactable : MonoBehaviour
//{
//    [Tooltip("Distance from which the player can interact")]
//    public float interactionDistance = 5f;

//    protected Transform player;

//    protected virtual void Start()
//    {
//        // Find the player in the scene
//        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
//        if (playerObj != null)
//        {
//            player = playerObj.transform;
//        }
//        else
//        {
//            Debug.LogError("No GameObject with tag 'Player' found in the scene! Please assign it.");
//        }
//    }

//    protected virtual void Update()
//    {
//        // Check distance to player
//        if (player != null && Vector3.Distance(transform.position, player.position) <= interactionDistance)
//        {
//            // Check for joystick button press (A button = JoystickButton0)
//            if (Input.GetKeyDown(KeyCode.JoystickButton0))
//            {
//                OnInteract();
//            }
//        }
//    }

//    // This is overridden by child classes
//    public virtual void OnInteract()
//    {
//        Debug.Log($"{gameObject.name} interacted!");
//    }

//}
//using UnityEngine;

//public class Interactable : MonoBehaviour
//{
//    [Tooltip("Distance from which the player can interact")]
//    public float interactionDistance = 3f;

//    protected Transform player;

//    protected virtual void Start()
//    {
//        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
//        if (playerObj != null) player = playerObj.transform;
//        else Debug.LogError("Player object not found! Tag your player as 'Player'.");
//    }

//    protected virtual void Update()
//    {
//        if (player != null && Vector3.Distance(transform.position, player.position) <= interactionDistance)
//        {
//            if (Input.GetKeyDown(KeyCode.JoystickButton0))
//                OnInteract();
//        }
//    }

//    // Override in child classes
//    public virtual void OnInteract()
//    {
//        Debug.Log($"{gameObject.name} interacted!");
//    }
//}
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Tooltip("Optional: can override distance checks, but handled by PlayerController raycast")]
    public float interactionDistance = 3f;

    // To be overridden
    public virtual void OnInteract()
    {
        Debug.Log($"{gameObject.name} interacted!");
    }
}
