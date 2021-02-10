using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnchangeableClothState : State
{
    public void setChangeability(StateHandler context, bool changeability)
    {
        if (changeability)
        {
            context.labelText.text = context.changingAllowedStateText;
            AvatarController.anim.SetTrigger("Tpose");

            foreach (var ui in StateHandler.changingClothUI)
            {
                ui.SetActive(true);
            }

            foreach (var cloth in context._allCloths)
            {
                cloth.ClearTransformMotion();
                cloth.enabled = false;
            }

            context.setState(new ChangeableClothState());
        }
    }

    public void setSymmetricity(StateHandler context, bool symmetricity)
    {
        if (symmetricity)
        {
            context.setState(new UnchangeableClothSymmetricState());
        }
    }

    public void strechCorrespondingPart(LenghtenSingleClothSymmetrically context, float scaleFactor)
    {

    }
}
