using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModifyCloth : MonoBehaviour
{
    protected SingleCloth clothToHandle;
    [SerializeField] protected string tag = "top";
    
    void Awake()
    {
        GetClothToHandle();
    }
    
    private void GetClothToHandle()
    {
        clothToHandle = GameObject.FindWithTag(tag).GetComponent<SingleCloth>();
    }

    public abstract void ModifyClothProperties(float scaleFactor);

    // Update is called once per frame
    void Update()
    {
        
    }
}
