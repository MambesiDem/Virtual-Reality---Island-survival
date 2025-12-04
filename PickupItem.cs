//using UnityEngine;

//public class PickupItem : Interactable
//{
//    [Tooltip("Name of the item to add to inventory")]
//    public string itemName = "Log";

//    [Tooltip("Optional pickup sound")]
//    public AudioClip pickupSound;

//    public override void OnInteract()
//    {
//        base.OnInteract();
//        Inventory.Instance.AddItem(itemName);
//        if (pickupSound != null) AudioSource.PlayClipAtPoint(pickupSound, transform.position);
//        gameObject.SetActive(false);
//        UIManager.Instance?.ShowMessage($"{itemName} picked up!");
//    }

//}
using UnityEngine;

public class PickupItem : Interactable
{
    public override void OnInteract()
    {
        if (gameObject.CompareTag("Log"))
        {
            Inventory.Instance.AddItem("Log", 1);
            Debug.Log("Picked up log!");
        }
        else
        {
            Inventory.Instance.AddItem("Stone", 1);
            Debug.Log("Picked up Stone!");
        }
        Destroy(gameObject);
    }
}

