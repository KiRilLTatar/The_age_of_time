using UnityEngine;

public class Hightlightable : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color originalColor;
    public Color highlightColor = Color.yellow; 

    void Awake() 
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }
        else
        {
            Debug.LogWarning("������ Highlightable ������� ��������� Renderer �� " + gameObject.name);
        }
    }

    public void Highlight()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = highlightColor;
        }
    }

    public void Unhighlight()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor;
        }
    }
}
