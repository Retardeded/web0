using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChangingUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StateHandler.AddToChagingUI(this.gameObject);
        AdditionalStartSetup();
    }

    public virtual void AdditionalStartSetup()
    {
        
    }
}
