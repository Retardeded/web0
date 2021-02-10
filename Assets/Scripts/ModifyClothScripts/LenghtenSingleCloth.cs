using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LenghtenSingleCloth : ModifySingleCloth
{
    [SerializeField] protected int clothPartIndex;
    protected bool scaleDownSlider = true;

    public override void AdditionalStartSetup()
    {
        if (Mathf.Abs(slider.maxValue) > Mathf.Abs(slider.minValue))
            scaleDownSlider = true;
        else
        {
            scaleDownSlider = false;
        }
    }

    public override void ModifyCloth()
    {
        float scaleFactor = slider.value;
        clothToHandle.changeClothPart(clothPartIndex);
        clothToHandle.lengthenClothPart(scaleFactor, scaleDownSlider);
    }
}
