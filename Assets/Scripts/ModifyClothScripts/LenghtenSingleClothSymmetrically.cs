using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LenghtenSingleClothSymmetrically : LenghtenSingleCloth
{
    [SerializeField] protected int symmetricClothPartIndex = 0;
    
    public override void ModifyCloth()
    {
        float scaleFactor = slider.value;
        clothToHandle.changeClothPart(clothPartIndex);
        clothToHandle.lengthenClothPart(scaleFactor, scaleDownSlider);

        StateHandler.StrechCorrespondingPart(this, scaleFactor);
    }

    public void StrechCorrespondingPart(float scaleFactor)
    {
        clothToHandle.changeClothPart(symmetricClothPartIndex);
        clothToHandle.lengthenClothPart(scaleFactor, scaleDownSlider);
    }
}