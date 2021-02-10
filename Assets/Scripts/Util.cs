using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static void setTrousersConstraints(ClothSkinningCoefficient[] newConstraints)
    {
        for (int i = 0; i < newConstraints.Length / 10; i++)
        {
            newConstraints[i].maxDistance = 0.02f;
            newConstraints[i + newConstraints.Length / 2 + newConstraints.Length / 10].maxDistance = 0.02f;
        }
    }
    
    public static void setSkirtConstraints(ClothSkinningCoefficient[] newConstraints)
    {
        for (int i = 0; i < newConstraints.Length / 4; i++)
        {
            newConstraints[i].maxDistance = 0.02f;
        }
    }
}
