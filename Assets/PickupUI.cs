using UnityEngine;
using TMPro;

public class PickupUI : MonoBehaviour
{
    public TextMeshProUGUI pickupText;
    private int pickupCount = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject); // Сохраняет UI при смене сцены
    }

    public void UpdatePickupCount()
    {
        pickupCount++;
        pickupText.text = "Items: " + pickupCount;
    }
}