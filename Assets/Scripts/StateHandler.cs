using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StateHandler : MonoBehaviour
{
    // Start is called before the first frame update
    /*public enum State 
    {
      ChangeCloth,
      ChangeClothSymmetric,
      UnchangableCloth,
      UnchangableClothSymmetric
      //klasa dziedziczy po bazowej, obiket mowi w jakim jest stanie, obikety dziedzicza handler i to ona w sobie mowi jaki jest stan
    }*/

    [SerializeField] public TextMeshProUGUI labelText;

    public string changingAllowedStateText = "Check this to see how cloth behaves";
    public string unchangableClothsStateText = "Check this to change cloths";
    string changingUITag = "changingclothui";

    public static State state;

    public Toggle _toggle;
    public GameObject symmetricToogle;
    public static List<GameObject> changingClothUI;
    public List<Cloth> _allCloths = new List<Cloth>();

    public void setState(State s)
    {
        state = s;
    }

    public static State getState()
    {
        return state;
    }

    public void SetSymmetricity(bool symmetricStretch)
    {
        state.setSymmetricity(this, symmetricStretch);
    }

    public void SetChangeability(bool allowChange)
    {
        state.setChangeability(this, allowChange);
    }

    public static void StrechCorrespondingPart(LenghtenSingleClothSymmetrically context, float factor)
    {
        state.strechCorrespondingPart(context, factor);
    }

    private void Awake()
    {
        changingClothUI = new List<GameObject>();
        changingClothUI.Add(symmetricToogle);
    }

    void Start()
    {
        state = new UnchangeableClothSymmetricState();
        SingleCloth[] singleCloths = FindObjectsOfType<SingleCloth>();
        foreach (var cloth in singleCloths)
        {
            _allCloths.Add(cloth.GetComponent<Cloth>());
        }
        
        //changingClothUI = GameObject.FindGameObjectsWithTag(changingUITag);
        _toggle = GetComponent<Toggle>();
        _toggle.isOn = true;

        state.setChangeability(this, true);
    }

    public static void AddToChagingUI(GameObject obj)
    {
        changingClothUI.Add(obj);
    }
}
