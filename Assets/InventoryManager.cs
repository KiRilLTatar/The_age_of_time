using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public void AddItem(string itemName)
    {
        Debug.Log("Добавлен предмет: " + itemName);
    }
}