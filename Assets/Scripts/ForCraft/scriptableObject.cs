using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public int quantity;

    public InventoryItem(string name)
    {
        this.itemName = name;
        this.quantity = 1;
    }
}
