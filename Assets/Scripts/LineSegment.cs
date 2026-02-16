using UnityEngine;

public class LineSegment : MonoBehaviour
{
    private bool isClicked = false;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) Debug.LogError("SpriteRenderer component not found on LineSegment GameObject.");
        spriteRenderer.color = Color.white; // Set initial color to white
    }

    public void Toggle()
    {
        isClicked = !isClicked;
        if (spriteRenderer == null) Debug.LogError("SpriteRenderer component not found on LineSegment GameObject.");

        spriteRenderer.color = isClicked ? Color.red : Color.white; // Change color based on click state
    }
}
