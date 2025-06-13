using UnityEngine;
using TMPro;

public class PickupUI : MonoBehaviour
{
    public TextMeshProUGUI pickupText;
    private int pickupCount = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject); // ��������� UI ��� ����� �����
    }

    public void UpdatePickupCount()
    {
        pickupCount++;
        pickupText.text = "Items: " + pickupCount;
    }
}