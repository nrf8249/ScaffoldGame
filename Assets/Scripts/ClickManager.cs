using UnityEngine;
using UnityEngine.InputSystem;

public class ClickManager : MonoBehaviour
{
    public void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log("Click detected: " + context.phase);
        if (!context.performed) return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        if (hit.collider != null)
        {
            LineSegment line = hit.collider.GetComponent<LineSegment>();
            if (line != null)
            {
                Debug.Log("Clicked on line segment at: " + line.transform.position);
                line.Toggle();
            }
        }
    }
}
