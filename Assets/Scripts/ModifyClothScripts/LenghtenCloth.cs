using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LenghtenCloth : ModifyCloth
{
    [SerializeField] protected int clothPartIndex;
    protected bool scaleDownSlider = true;
    void Start()
    {
        Slider slider = GetComponent<Slider>();
        if (Mathf.Abs(slider.maxValue) > Mathf.Abs(slider.minValue))
            scaleDownSlider = true;
        else
        {
            scaleDownSlider = false;
        }
    }

    public override void ModifyClothProperties(float scaleFactor)
    {
        clothToHandle.changeClothPart(clothPartIndex);
        clothToHandle.lengthenClothPart(scaleFactor, scaleDownSlider);
    }
}
