using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel;

    public TextMeshProUGUI crystalText;
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI metalText;

    private int crystalCount = 0;
    private int woodCount = 0;
    private int metalCount = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }

    public void AddItem(string itemName)
    {
        switch (itemName)
        {
            case "Crystal":
                crystalCount++;
                crystalText.text = crystalCount.ToString();
                break;
            case "Wood":
                woodCount++;
                woodText.text = woodCount.ToString();
                break;
            case "Metal":
                metalCount++;
                metalText.text = metalCount.ToString();
                break;
        }
    }
}
