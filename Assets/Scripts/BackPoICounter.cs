using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BackPoICounter : MonoBehaviour
{
    public float AngleThreshold = 85f;
    TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        int Counter = 0;
        Vector3 GlobePosition = GameManager.Instance.Globe.transform.position;
        Vector3 TestDirection = new Vector3(0, 0, 1);
        foreach (PoI PointOfInterest in GameManager.Instance.PointsOfInterest)
        {
            Vector3 direction = -PointOfInterest.transform.up;
            if(Vector3.Angle(direction, TestDirection) < AngleThreshold)
            {
                Counter++;
            }
        }
        text.text = Counter.ToString();
    }
}
