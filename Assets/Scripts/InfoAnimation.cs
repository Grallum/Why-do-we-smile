using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoAnimation : MonoBehaviour
{


    public virtual void Animate(float alpha)
    {

    }


    // Start is called before the first frame update
    protected virtual void Start()
    {
        GameManager.Instance.infoAnimationComponents.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
