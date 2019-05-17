using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables;

public class RangeSlider : SliderController
{
    public Rotate rotate;
    public Text text;

    protected override void OnStart()
    {
        slider.SetPositionTarget((slider.stepValueRange.maximum + rotate.range) / slider.stepValueRange.Distance(), 10);
    }

    protected override void OnUpdate()
    {
        text.text = rotate.range + "";
    }

    protected override void ValueChanged(object sender, ControllableEventArgs e)
    {
        rotate.range = e.value;
    }
}
