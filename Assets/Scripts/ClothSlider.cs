using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ClothSlider : ChangingUI
{
    public Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate {ModifyCloth(); });
        AdditionalAwakeSetup();
    }

    public virtual void AdditionalAwakeSetup()
    {
        
    }
    public abstract void ModifyCloth();
}
