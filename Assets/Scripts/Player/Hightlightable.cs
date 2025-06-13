using UnityEngine;

public class Hightlightable : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color originalColor;
    private bool isHighlighted = false;

    [Header("Highlight Settings")]
    public Color highlightColor = Color.yellow;

    void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            objectRenderer.material = new Material(objectRenderer.material);
            originalColor = objectRenderer.material.color;
        }
        else
        {
            Debug.LogWarning("Скрипт Hightlightable требует компонент Renderer на " + gameObject.name);
        }
    }

    public void Highlight()
    {
        if (objectRenderer != null && !isHighlighted)
        {
            objectRenderer.material.color = highlightColor;
            isHighlighted = true;
        }
    }

    public void Unhighlight()
    {
        if (objectRenderer != null && isHighlighted)
        {
            objectRenderer.material.color = originalColor;
            isHighlighted = false;
        }
    }
}
