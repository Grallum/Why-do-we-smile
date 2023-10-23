using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private GameObject Globe;
    private GameObject Camera;



    public bool PlayerCanRotate = false;
    public bool IsAnimating = false;

    Quaternion RotateFromA;
    Quaternion RotateFromB;
    Quaternion RotateToA;
    Quaternion RotateToB;

    float RotateAlpha;

    public List<InfoAnimation> infoAnimationComponents = new List<InfoAnimation>();

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
        testTime += Time.deltaTime;
        testTime = testTime % 1f;
        Debug.Log("test");
        foreach(InfoAnimation iAC in infoAnimationComponents)
        {
            Debug.Log("test2");

            iAC.Animate(testTime);
        }
    }

    public void RotateGlobeTo(Vector3 EulerRotateTo)
    {
        
        Globe.GetComponent<GlobeDrag>().RotateAnimate(EulerRotateTo, 1f);
        
    }


    public void ShowInfo(PoI poi)
    {

    }
}
