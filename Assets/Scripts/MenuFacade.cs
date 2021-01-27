using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFacade : MonoBehaviour
{
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

    [SerializeField] Toggle toggleState;

    List<SliderData> sliders = new List<SliderData>();
    CameraController cameraController;
    
    public struct SliderData {
        public Slider slider;
        public float defaultValue;
        
        public SliderData(Slider slider, float defaultValue)
        {
            this.slider = slider;
            this.defaultValue = defaultValue;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
        Slider[] slidersObjs = FindObjectsOfType<Slider>();
        foreach (var slider in slidersObjs)
        {
            SliderData data = new SliderData(slider, slider.value);
            sliders.Add(data);
        }

        select(0);
    }

    public void select(int index)
    {
        switch (index)
        {
            case 0: //reset
                setCameraPosition(2f, 0, 0);
                setSliders(0, 0, 0, 0, 0, 0,
                    0.9f, 1f, 0, 0.9f, 1f, 0);
                break;

            case 1: //turbine
                setCameraPosition(2f, 0, 0);
                setSliders(0, 0, 0, 0, 0, 0,
                    0.9f, 0.2f, 0, 0.5f, 1f, 0);
                break;

            case 2: //girl
                setCameraPosition(2f, 0, 0);
                setSliders(-2f, -2f, 0, 0, 0, 0,
                    0.9f, 1f, 0, 0.9f, 1f, 5);
                break;
            case 3: //superman
                setCameraPosition(2f, 0, 0);
                setSliders(-2f, -2f, 0, 0, 0, 0,
                    1f, 1f, 4, 0.9f, 1f, 0);
                break;
            case 4: //hard reset
                Scene scene = SceneManager.GetActiveScene(); 
                SceneManager.LoadScene(scene.name);
                break;
        }
    }

    private void setCameraPosition(float r, float lat, float lon)
    {
        cameraController.setPosition(r, lat, lon);
    }

    private void restSliders()
    {
        foreach (var sliderData in sliders)
        {
            sliderData.slider.value = sliderData.defaultValue;
        }
    }

    private void setSliders(float rightArm, float leftArm, float tors, float belly, float leftLeg, float rightLeg,
        float topStretchiness, float stretchTop, int changeTop, float bottomStretchiness, float stretchBottom, int changeBottom)
    {
        this.rightArm.value = rightArm;
        this.leftArm.value = leftArm;
        this.tors.value = tors;
        this.belly.value = belly;
        this.leftLeg.value = leftLeg;
        this.rightLeg.value = rightLeg;

        this.topStretchiness.value = topStretchiness;
        this.stretchTop.value = stretchTop;
        this.changeTop.value = changeTop;
        this.bottomStretchiness.value = bottomStretchiness;
        this.stretchBottom.value = stretchBottom;
        this.changeBottom.value = changeBottom;
    }
}
