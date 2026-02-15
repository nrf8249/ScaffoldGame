using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSegment : MonoBehaviour
{
    private bool isClicked = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white; // Set initial color to white

    }
    public void Toggle()
    {
        isClicked = !isClicked;
        spriteRenderer.color = isClicked ? Color.red : Color.white; // Change color based on click state
    }
}
