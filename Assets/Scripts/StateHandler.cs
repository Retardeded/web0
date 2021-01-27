using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StateHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public enum State 
    {
      ChangeCloth,
      ChangeClothSymmetric,
      UnchangableCloth,
      UnchagnableClothSymmetric
    }
    
    [SerializeField] private TextMeshProUGUI labelText;
    
    private string changingAllowedStateText = "Changing cloths allowed";
    private string unchangableClothsStateText = "Check this to change cloths";
    string changingUITag = "changingclothui";
    
    public static State STATE = State.ChangeClothSymmetric;
    private Toggle _toggle;
    private GameObject[] changingClothUI;
    private List<Cloth> _allCloths = new List<Cloth>();

    public void MakeStretchingSymmetric(bool symmetricStretch)
    {
        if (symmetricStretch)
        {
            STATE = State.ChangeClothSymmetric;
        }
        else
        {
            STATE = State.ChangeCloth;
        }
    }

    public void ChangeState(bool allowChange)
    {
        if (!allowChange)
        {

            if (STATE == State.ChangeClothSymmetric)
            {
                STATE = State.UnchagnableClothSymmetric;
            }
            else
            {
                STATE = State.UnchangableCloth;
            }
            labelText.text = unchangableClothsStateText;
            foreach (var ui in changingClothUI)
            {
                ui.SetActive(false);
            }


            foreach (var cloth in _allCloths)
            {
                if (cloth.tag == "bottom")
                {
                    cloth.enabled = true;
                    ClothSkinningCoefficient[] newConstraints; 
                    newConstraints = cloth.coefficients;
                    for (int i = 0; i < newConstraints.Length/10; i++)
                    {
                        newConstraints[i].maxDistance = 0.02f;
                        newConstraints[i + newConstraints.Length/2 + newConstraints.Length/10].maxDistance = 0.02f;
                    }
                    cloth.coefficients = newConstraints;
                    cloth.enabled = false;
                }
                
                cloth.enabled = true;
            }
        }
        else
        {
            if (STATE == State.UnchagnableClothSymmetric)
            {
                STATE = State.ChangeClothSymmetric;
            }
            else
            {
                STATE = State.ChangeCloth;
            }
            labelText.text = changingAllowedStateText;
            AvatarController.anim.SetTrigger("Tpose");
            
            foreach (var ui in changingClothUI)
            {
                ui.SetActive(true);
            }
            
            foreach (var cloth in _allCloths)
            {
                cloth.ClearTransformMotion();
                cloth.enabled = false;
            }
        }
    }
    void Start()
    {
        SingleCloth[] singleCloths = FindObjectsOfType<SingleCloth>();
        foreach (var cloth in singleCloths)
        {
            _allCloths.Add(cloth.GetComponent<Cloth>());
        }
        changingClothUI = GameObject.FindGameObjectsWithTag(changingUITag);
        _toggle = GetComponent<Toggle>();
        _toggle.isOn = false;
        ChangeState(false);
    }
}
