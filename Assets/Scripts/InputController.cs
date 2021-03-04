using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    static public bool arrowKeySetting;
    static public float maximumSpeed;
    public Toggle ArrowsOrMouse;
    //public float minSlider;
    //public float maxSlider;

    public Slider SpeedSlider;

    //These function will be referenced in the settings toggle "On Value Changed (Boolean)"
    public void ArrowControlSetting()
    {
        arrowKeySetting = ArrowsOrMouse; //gets true or false from whether box is checked and assigns it to the arrowKeySetting variable
    }


    public void UserSetMaxSpeed()
    {
        maximumSpeed = SpeedSlider.value;
    }
}
