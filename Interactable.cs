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
