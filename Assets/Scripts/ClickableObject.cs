using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public Texture2D HoverCursor;
    private bool isHovering;

    public bool IsHovering
    {
        get { return isHovering; } 
    }

    virtual public void UpdateCursor()
    {
        if (isHovering == true)
        {
            Cursor.SetCursor(HoverCursor, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(texture: null, Vector2.zero, CursorMode.Auto);
        }
    }

    protected virtual void OnMouseEnter() {
        isHovering = true;
        UpdateCursor();
    }

    protected virtual void OnMouseExit() {
        isHovering = false;
        UpdateCursor();
    }
}
