using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustMaterialStretchtness: ModifyCloth
{
    private Cloth _cloth;
    
    public override void ModifyClothProperties(float scaleFactor)
    {
        _cloth.stretchingStiffness = scaleFactor;
        _cloth.bendingStiffness = scaleFactor;
    }

    void Start()
    {
        _cloth = clothToHandle.GetComponent<Cloth>();
    }
}
