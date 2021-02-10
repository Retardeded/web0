using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustMaterialStretchtness: ModifySingleCloth
{
    private Cloth _cloth;
    
    public override void ModifyCloth()
    {
        float scaleFactor = slider.value;
        _cloth.stretchingStiffness = scaleFactor;
        _cloth.bendingStiffness = scaleFactor;
    }

    public override void AdditionalStartSetup()
    {
        _cloth = clothToHandle.GetComponent<Cloth>();
    }
}
