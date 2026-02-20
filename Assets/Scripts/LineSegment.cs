using UnityEngine;

public class LineSegment : Puzzle
{
    private bool isClicked = false;
    private SpriteRenderer spriteRenderer;
    private int x, y;
    private bool horiz;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) Debug.LogError("SpriteRenderer component not found on LineSegment GameObject.");
        spriteRenderer.color = Color.gray6; // Set initial color to white
    }

    public void Toggle()
    {
        isClicked = !isClicked;
        if (spriteRenderer == null) Debug.LogError("SpriteRenderer component not found on LineSegment GameObject.");


        // Update status lists when clicked, used for checking accuracy
        //if (horiz) horizStatus[this.x * data.size + y] = isClicked ? 1 : 0;
        //else vertStatus[this.x * data.size + y] = isClicked ? 1 : 0;
        
        //foreach (int i in horizStatus) Debug.Log(i);
        //foreach (int j in vertStatus) Debug.Log(j);

        spriteRenderer.color = isClicked ? Color.black : Color.gray6; // Change color based on click state
    }

    public void setInfo(int x, int y, bool horiz)
    {
        this.x = x;
        this.y = y;
        this.horiz = horiz;
    }
}
