using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModifySingleCloth : ClothSlider
{
    protected SingleCloth clothToHandle;
    [SerializeField] protected string tag = "top";
    
    public override void AdditionalAwakeSetup()
    {
        GetClothToHandle();
    }
    
    private void GetClothToHandle()
    {
        clothToHandle = GameObject.FindWithTag(tag).GetComponent<SingleCloth>();
    }
    
    
}
