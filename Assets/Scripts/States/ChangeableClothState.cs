using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeableClothState : State
{
    public void setChangeability(StateHandler context, bool changeability)
    {
        if (!changeability)
        {
            context.labelText.text = context.unchangableClothsStateText;

            foreach (var ui in StateHandler.changingClothUI)
            {
                ui.SetActive(false);
            }


            foreach (var cloth in context._allCloths)
            {
                if (cloth.tag == "bottom")
                {   
                    cloth.enabled = true;
                    ClothSkinningCoefficient[] newConstraints;
                    newConstraints = cloth.coefficients;
                    if(cloth.GetComponent<SingleCloth>().currentClothName.Contains("spodnie"))
                        Util.setTrousersConstraints(newConstraints);
                    else
                        Util.setSkirtConstraints(newConstraints);
                    
                    cloth.coefficients = newConstraints;
                    cloth.enabled = false;
                }

                cloth.enabled = true;
            }

            context.setState(new UnchangeableClothState());
        }
    }

    public void setSymmetricity(StateHandler context, bool symmetricity)
    {
        if (symmetricity)
        {
            context.setState(new ChangeableClothSymmetricState());
        }
    }

    public void strechCorrespondingPart(LenghtenSingleClothSymmetrically context, float scaleFactor)
    {

    }
}
