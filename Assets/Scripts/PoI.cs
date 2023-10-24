using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoI : ClickableObject
{
    public Color UICOlor = Color.red;
    //public GUIStyle UIText = "";

    public Vector2 TargetRotation;

    void Start()
    {
        GameManager.Instance.PointsOfInterest.Add(this);    
    }

    private void OnDestroy()
    {
        GameManager.Instance.PointsOfInterest.Remove(this);
    }

    private void OnClick()
    {
        Vector3 Euler = transform.parent.transform.localRotation.eulerAngles;


        Vector3 NewEuler = new Vector3();
        NewEuler.x = -Euler.x;
        NewEuler.y = -Euler.y;


        while(NewEuler.x < -90f)
        {
            NewEuler.x += 360f;
        }

        while (NewEuler.x > 90f)
        {
            NewEuler.x -= 360f;
        }

        GameManager.Instance.RotateGlobeTo(NewEuler);



    }

    protected virtual void OnMouseDown()
    {
        if (IsHovering)
        {
            OnClick();
        }
    }

}
