using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject Globe { get; private set; }
    private GameObject Camera;

    public bool PlayerCanRotate = false;
    public bool IsAnimating = false;


    public List<InfoAnimation> infoAnimationComponents = new List<InfoAnimation>();
    public List<PoI> PointsOfInterest = new List<PoI>();

    public float AnimationSpeed = 2f;

    float testTime = 0;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerCanRotate = true;
        Globe = GameObject.FindGameObjectsWithTag("Globe")[0];
        Camera = GameObject.FindGameObjectsWithTag("MainCamera")[0];

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RotateGlobeTo(Vector3 EulerRotateTo)
    {
        
        Globe.GetComponent<GlobeDrag>().RotateAnimate(EulerRotateTo, AnimationSpeed);
        
    }


    public void ShowInfo(PoI poi)
    {

    }
}
