using UnityEngine;

public class WoodPickup : MonoBehaviour
{
    public string itemName = "Wood";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<InventoryManager>().AddItem(itemName);
            Destroy(gameObject);
        }
    }
}