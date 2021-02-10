using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFacade : ChangingUI
{
    [SerializeField] ClothManager clothManager;

    [SerializeField] Slider rightArm;
    [SerializeField] Slider leftArm;
    [SerializeField] Slider tors;
    [SerializeField] Slider belly;
    [SerializeField] Slider leftLeg;
    [SerializeField] Slider rightLeg;

    [SerializeField] Slider topStretchiness;
    [SerializeField] Slider stretchTop;
    [SerializeField] Slider changeTop;
    [SerializeField] Slider bottomStretchiness;
    [SerializeField] Slider stretchBottom;
    [SerializeField] Slider changeBottom;

    [SerializeField] Slider topRed;
    [SerializeField] Slider topGreen;
    [SerializeField] Slider topBlue;
    [SerializeField] Slider bottomRed;
    [SerializeField] Slider bottomGreen;
    [SerializeField] Slider bottomBlue;

    [SerializeField] Toggle toggleState;

    List<SliderData> sliders = new List<SliderData>();
    CameraController cameraController;

    public struct SliderData
    {
        public Slider slider;
        public float defaultValue;

        public SliderData(Slider slider, float defaultValue)
        {
            this.slider = slider;
            this.defaultValue = defaultValue;
        }
    }

    // Start is called before the first frame update
    public override void AdditionalStartSetup()
    {
        cameraController = FindObjectOfType<CameraController>();
        Slider[] slidersObjs = FindObjectsOfType<Slider>();
        foreach (var slider in slidersObjs)
        {
            SliderData data = new SliderData(slider, slider.value);
            sliders.Add(data);
        }

        tors.minValue = -0.7f;
        leftArm.minValue = -1f;
        rightArm.minValue = -1f;

        select(0);
    }

   

    public void select(int index)
    {
        switch (index)
        {
            case 0: //reset
                changeCloth("niekaptur");
                changeCloth("duze_spodnie");

                setCameraPosition(2f, 0, 0);
                setColors(0.92f, 0.7f, 0.1f, 0, 0, 1);
                setTopProperties(0, 0, 0, 0.9f, 1f);
                setBottomProperties(0, 0, 0, 0.9f, 1f);

                break;

            case 1: //turbine
                changeCloth("kaptur");
                changeCloth("spodnie1");

                setCameraPosition(2f, 0, 0);
                setColors(1, 1, 1, 0, 0, 0);
                setTopProperties(0, 0, 0, 0.7f, 0.2f);
                setBottomProperties(0, 0, 0, 0.5f, 1f);

                break;

            case 2: //girl
                changeCloth("top1");
                changeCloth("spodnica");

                setCameraPosition(3f, -30, -30);
                setColors(1, 0.5f, 0, 0, 0, 0);
                setTopProperties(-0.5f, -0.5f, -0.7f, 0.9f, 1f);
                setBottomProperties(0, 0, 0, 0.9f, 1f);

                break;
            case 3: //balerina
                changeCloth("top2");
                changeCloth("balerina");

                setCameraPosition(3f, -30, 30);
                setColors(1, 1, 1, 1f, 0.75f, 0.75f);
                setTopProperties(-0.7f, -0.7f, 0, 0.9f, 1f);
                setBottomProperties(0, 0, 0, 0.9f, 1f);

                break;
            case 4: //superman
                changeCloth("peleryna");
                changeCloth("spodnie1");

                setCameraPosition(3f, -45, 0);
                setColors(1, 0, 0, 0, 0, 1);
                setTopProperties(0, 0, 0, 1f, 1f);
                setBottomProperties(0, 0, 0, 0.9f, 1f);

                break;
            case 5: //hard reset
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
                break;
        }
    }

    private void changeCloth(string name)
    {
        if (ClothManager.top2ix.ContainsKey(name))
        {
            int ix = ClothManager.top2ix[name];
            changeTop.value = ix;
        }
        else if (ClothManager.bottom2ix.ContainsKey(name))
        {
            int ix = ClothManager.bottom2ix[name];
            changeBottom.value = ix;
        }
    }

    private void setCameraPosition(float r, float lat, float lon)
    {
        cameraController.setPosition(r, lat, lon);
    }

    private void setColors(float tr, float tg, float tb, float br, float bg, float bb)
    {
        topRed.value = tr;
        topGreen.value = tg;
        topBlue.value = tb;
        bottomRed.value = br;
        bottomGreen.value = bg;
        bottomBlue.value = bb;
    }

    private void setTopProperties(float rightArm, float leftArm, float tors,
        float topStretchiness, float stretchTop)
    {
        this.rightArm.value = rightArm;
        this.leftArm.value = leftArm;
        this.tors.value = tors;

        this.topStretchiness.value = topStretchiness;
        this.stretchTop.value = stretchTop;
    }

    private void setBottomProperties(float belly, float leftLeg, float rightLeg,
         float bottomStretchiness, float stretchBottom)
    {
        this.leftLeg.value = leftLeg;
        this.rightLeg.value = rightLeg;
        this.belly.value = belly;

        this.bottomStretchiness.value = bottomStretchiness;
        this.stretchBottom.value = stretchBottom;
    }

    private void restSliders()
    {
        foreach (var sliderData in sliders)
        {
            sliderData.slider.value = sliderData.defaultValue;
        }
    }
}
