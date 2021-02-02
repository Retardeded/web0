using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSingleColor : ModifyCloth
{
    [SerializeField] private char colorPart;

    private void Start()
    {
        Slider slider = GetComponent<Slider>();
        slider.wholeNumbers = false;
        slider.minValue = 0;
        slider.maxValue = 1;
    }

    public override void ModifyClothProperties(float scaleFactor)
    {
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