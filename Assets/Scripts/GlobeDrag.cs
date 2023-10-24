using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class GlobeDrag : MonoBehaviour
{
    Vector3 mPrevPos = Vector3.zero;

    public float RotationSpeedModifier = 50f;
    public float MaxXRotation = 20f;
    Vector2 GlobeRotation = new Vector2();


    bool isAnimating = false;
    Vector2 StartGlobeRotation = new Vector2();
    Vector2 TargetGlobeRotation = new Vector2();
    float AnimationAlpha;
    float AnimationSpeed;

    DragCursor ClickableObject;

    private void Start()
    {
        GlobeRotation.x = transform.parent.transform.localRotation.eulerAngles.x;
        if(GlobeRotation.x > 180f)
        {
            GlobeRotation.x -= 360f;
        }

        GlobeRotation.y = transform.localRotation.eulerAngles.y;

        ClickableObject = GetComponent<DragCursor>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mPosDelta = (Input.mousePosition - mPrevPos) * RotationSpeedModifier * Time.deltaTime;
        mPrevPos = Input.mousePosition;

        if (!isAnimating)
        {
            //Change rotation based on mouse
            if (ClickableObject.IsMouseDown)
            {
                GlobeRotation.y = (GlobeRotation.y - mPosDelta.x) % 360f;
                GlobeRotation.x = Mathf.Clamp(GlobeRotation.x + mPosDelta.y, -MaxXRotation, MaxXRotation);
            }
        }
        else
        {
            //Change rotation based on
            GlobeRotation = Vector2.Lerp(StartGlobeRotation, TargetGlobeRotation, AnimationAlpha);

            AnimationAlpha += Time.deltaTime * AnimationSpeed;
            if(AnimationAlpha > 1f)
            {
                GlobeRotation = TargetGlobeRotation;
                isAnimating = false;
            }
        }

        //Update globe rotation
        Vector3 CurrentGlobeEuler = transform.localRotation.eulerAngles;
        CurrentGlobeEuler.y = GlobeRotation.y;
        transform.localRotation = Quaternion.Euler(CurrentGlobeEuler);

        Vector3 CurrentParentEuler = transform.parent.transform.localRotation.eulerAngles;
        CurrentParentEuler.x = GlobeRotation.x;
        transform.parent.transform.localRotation = Quaternion.Euler(CurrentParentEuler);
    }


    public void RotateAnimate(Vector3 targetEulerRotation, float speed)
    {

        TargetGlobeRotation.x = targetEulerRotation.x;
        TargetGlobeRotation.y = targetEulerRotation.y;

        if(Mathf.Abs(targetEulerRotation.y + 360f - GlobeRotation.y) < Mathf.Abs(TargetGlobeRotation.y- GlobeRotation.y))
        {
            TargetGlobeRotation.y += 360;
        }
        if (Mathf.Abs(targetEulerRotation.y - 360f - GlobeRotation.y) < Mathf.Abs(TargetGlobeRotation.y - GlobeRotation.y))
        {
            TargetGlobeRotation.y -= 360;
        }

        StartGlobeRotation = GlobeRotation;
        AnimationAlpha = 0f;
        AnimationSpeed = speed;
        isAnimating = true;
    }
}
