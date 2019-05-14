using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimatior : MonoBehaviour
{
    public void Stop()
    {
		//Microscope_Manager._Instance.Stop();
		Microscope_Manager._Instance.SetNextGO();
    }
    public void Play()
    {
        //Microscope_Manager._Instance.Play();
    }
}
