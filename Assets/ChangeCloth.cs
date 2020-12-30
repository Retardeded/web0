using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCloth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int clothPartIndex;
    [SerializeField] private string tag = "top";
    private SingleCloth clothToHandle;
    
    public void ChangeClothPart()
    {
        Debug.Log("chaing part");
        clothToHandle.changeClothPart(clothPartIndex);
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
