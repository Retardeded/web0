using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSingleColor : ModifySingleCloth
{
    [SerializeField] private char colorPart;

    public override void AdditionalStartSetup()
    {
        slider.wholeNumbers = false;
        slider.minValue = 0;
        slider.maxValue = 1;
    }

    public override void ModifyCloth()
    {
        float scaleFactor = slider.value;
        Color color = clothToHandle._skinnedMeshRenderer.material.color;
        switch (colorPart)
        {
            case 'r': //reset
                color.r = scaleFactor;
                break;
            case 'g': //reset
                color.g = scaleFactor;
                break;
            case 'b': //reset
                color.b = scaleFactor;
                break;
        }
        clothToHandle._skinnedMeshRenderer.material.color = color;
    }
    
}