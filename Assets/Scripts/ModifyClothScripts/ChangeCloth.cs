using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCloth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ClothManager _clothManager;
    [SerializeField] private bool isTop = true;
    
    void Awake()
    {
        Slider slider = GetComponent<Slider>();
        slider.minValue = 0;
        if(isTop)
            slider.maxValue = _clothManager.topSingleCloths.transform.childCount - 1;
        else
        {
            slider.maxValue = _clothManager.bottomSingleCloths.transform.childCount - 1;
        }
        slider.wholeNumbers = true;
    }

    public void ChangeCurrentTop(float index)
    {
        _clothManager.changeTop((int)index);
    }
    
    public void ChangeCurrentBottom(float index)
    {
        _clothManager.changeBottom((int)index);
    }
    
}
