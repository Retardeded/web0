using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCloth : ClothSlider
{
    // Start is called before the first frame update
    [SerializeField] private ClothManager _clothManager;
    [SerializeField] private bool isTop = true;
    
    public override void AdditionalStartSetup()
    {
        slider.minValue = 0;
        if(isTop)
            slider.maxValue = _clothManager.topSingleCloths.transform.childCount - 1;
        else
        {
            slider.maxValue = _clothManager.bottomSingleCloths.transform.childCount - 1;
        }
        slider.wholeNumbers = true;
    }

    public override void ModifyCloth()
    {
        float index = slider.value;
        
        if (isTop)
            _clothManager.changeTop((int) index);
        else _clothManager.changeBottom((int) index);
    }

}
