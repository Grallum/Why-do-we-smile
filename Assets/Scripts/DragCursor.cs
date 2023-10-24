using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCursor : ClickableObject
{
    public Texture2D ClickCursor;

    bool isMouseDown = false;

    public bool IsMouseDown
    {
        get { return isMouseDown; }
    }


    public override void UpdateCursor()
    {
        if (IsMouseDown)
        {
            Cursor.SetCursor(ClickCursor, Vector2.zero, CursorMode.Auto);

        }
        else
        {
            base.UpdateCursor();
        }
    }

    protected virtual void OnMouseDown()
    {
       
        if(IsHovering)
        {
            isMouseDown = true;
        }
        UpdateCursor();
    }

    protected virtual void OnMouseUp()
    {
        isMouseDown = false;
        UpdateCursor();
    }
}
