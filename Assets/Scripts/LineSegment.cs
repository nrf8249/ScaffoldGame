using UnityEngine;

public class LineSegment : MonoBehaviour
{
    public bool isClicked = false;
    private bool isNot = false;

    private int colorIndex = 0;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) Debug.LogError("SpriteRenderer component not found on LineSegment GameObject.");
        spriteRenderer.color = Color.gray6; // Set initial color to white
    }

    public void Toggle()
    {
        //isClicked = !isClicked;
        if (spriteRenderer == null) Debug.LogError("SpriteRenderer component not found on LineSegment GameObject.");

        colorIndex++;
        if (colorIndex > 2) { colorIndex = 0; }

        switch (colorIndex)
        {
            case 0:
                spriteRenderer.color = Color.gray6;
                break;
            case 1:
                spriteRenderer.color = Color.black;
                break;
            case 2:
                spriteRenderer.color = Color.red;
                break;
        }
         // Change color based on click state
    }

    public void ToggleNot()
    {
        isNot = !isNot;

        spriteRenderer.color = !isNot ? Color.gray6 : Color.red;
    }
}
