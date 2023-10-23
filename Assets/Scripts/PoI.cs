using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoI : ClickableObject
{
    public Color UICOlor = Color.red;
    //public GUIStyle UIText = "";

    public Vector2 TargetRotation;

    private void OnClick()
    {
        Vector3 Euler = transform.parent.transform.localRotation.eulerAngles;


        Vector3 NewEuler = new Vector3();
        NewEuler.x = -Euler.x;
        NewEuler.y = Euler.y;
        //GameManager.Instance.RotateGlobeTo(TargetRotation);



    }

    protected virtual void OnMouseDown()
    {
        if (IsHovering)
        {
            OnClick();
        }
    }

}
