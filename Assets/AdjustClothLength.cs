using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustClothLength : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int clothPartIndex;
    [SerializeField] private string tag = "top";
    private SingleCloth clothToHandle;
    private float scaleFactor = 0.1f;
    
    public void ChangeClothPart(float scaleFactor)
    {
        Debug.Log("chaing part");
        clothToHandle.changeClothPart(clothPartIndex);
        clothToHandle.lengthenClothPart(scaleFactor);
        //scaleFactor += 0.1f;
    }
    void Start()
    {
        GetClothToHandle();
    }

    private void GetClothToHandle()
    {
        clothToHandle = GameObject.FindWithTag("top").GetComponent<SingleCloth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}