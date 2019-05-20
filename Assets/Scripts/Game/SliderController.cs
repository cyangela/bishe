using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.ArtificialBased;

public class SliderController : MonoBehaviour {

    public VRTK_ArtificialSlider slider;
    private void Start()
    {
        OnStart();
    }
    private void Update()
    {
        OnUpdate();      
    }
    protected virtual void OnEnable()
    {
        if (slider != null)
            slider.ValueChanged += ValueChanged;       

    }
    protected virtual void OnDisable()
    {
        if (slider != null)
            slider.ValueChanged -= ValueChanged;
    }
    protected virtual void ValueChanged(object sender, VRTK.Controllables.ControllableEventArgs e){}
    protected virtual void OnStart(){ }
    protected virtual void OnUpdate() { }
}
