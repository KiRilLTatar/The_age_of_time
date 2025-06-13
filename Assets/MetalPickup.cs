using UnityEngine;

public class MetalPickup : MonoBehaviour
{
    public string itemName = "Metal";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<InventoryManager>().AddItem(itemName);
            Destroy(gameObject);
        }
    }
}