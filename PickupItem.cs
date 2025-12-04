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

