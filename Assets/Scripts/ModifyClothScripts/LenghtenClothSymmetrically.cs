using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LenghtenClothSymmetrically : LenghtenCloth
{
    [SerializeField] protected int symmetricClothPartIndex = 0;
    
    public override void ModifyClothProperties(float scaleFactor)
    {
        clothToHandle.changeClothPart(clothPartIndex);
        clothToHandle.lengthenClothPart(scaleFactor, scaleDownSlider);

        if (StateHandler.STATE == StateHandler.State.ChangeClothSymmetric)
        {
            clothToHandle.changeClothPart(symmetricClothPartIndex);
            clothToHandle.lengthenClothPart(scaleFactor, scaleDownSlider);
        }
    }
    
}