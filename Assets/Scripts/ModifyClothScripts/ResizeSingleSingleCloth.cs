using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeSingleSingleCloth : ModifySingleCloth
{
    public override void ModifyCloth()
    {
        float scaleFactor = slider.value;
        clothToHandle.transform.position = new Vector3(clothToHandle.transform.position.x, 1f-scaleFactor, clothToHandle.transform.position.z);
        clothToHandle.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

    }
}
