using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables;

public class SpeedSlider : SliderController
{
    public Rotate rotate;
    public Text text;

    protected override void OnStart()
    {
        slider.SetPositionTarget(rotate.speed / slider.stepValueRange.Distance(), 10);
    }

    protected override void OnUpdate()
    {
        text.text = rotate.speed + "";
    }

    protected override void ValueChanged(object sender, ControllableEventArgs e)
    {
        rotate.speed = e.value;
    }
}
