using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderInfo : InfoAnimation
{

    public override void Animate(float alpha)
    {
        transform.localScale = new Vector3(alpha, alpha, alpha);
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
