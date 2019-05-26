using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenLieEvent : MonoBehaviour {

    public void Play()
    {
        Cell_Manager._Instance.Play();
    }
    public void Pause()
    {
        Cell_Manager._Instance.Pause();
    }
}
