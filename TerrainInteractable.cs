using UnityEngine;

public class TerrainInteractable : Interactable
{
    [SerializeField] private GameObject stonePrefab;

    public override void OnInteract()
    {
        if (Inventory.Instance.UseItem("Stone", 1))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            Debug.Log("We're placing a stone.");
            if (Physics.Raycast(ray, out hit, 10f))
            {
            
                if (hit.collider.gameObject == this.gameObject)
                {
                    Vector3 dropPosition = hit.point;
                    dropPosition.y += 0.1f; 
                    Instantiate(stonePrefab, dropPosition, Quaternion.identity);
                }
            }
        }
        else
        {
            Debug.Log("You have no stones!");
        }

    }
}
