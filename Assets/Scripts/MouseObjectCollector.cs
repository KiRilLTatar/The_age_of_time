using UnityEngine;

public class MouseObjectCollector : MonoBehaviour
{
    [Header("Raycast Settings")]
    public float rayDistance = 100f;
    public LayerMask interactableLayer;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryCollectObjectUnderMouse();
        }
    }

    void TryCollectObjectUnderMouse()
    {
        if (mainCamera == null)
        {
            Debug.LogWarning("Main camera not found!");
            return;
        }

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, interactableLayer))
        {
            GameObject hitObject = hit.collider.gameObject;

            string tag = hitObject.tag;

            switch (tag)
            {
                case "Scrap":
                    InventoryManager.Instance.AddItem("Metal");
                    break;
                case "Ore":
                    InventoryManager.Instance.AddItem("Crystal");
                    break;
                case "Wood":
                    InventoryManager.Instance.AddItem("Wood");
                    break;
                default:
                    return;
            }

            Destroy(hitObject);
        }
    }
}
