using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
    public string itemName = "Crystal";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<InventoryManager>().AddItem(itemName);
            Destroy(gameObject);
        }
    }
}