using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.SceneManagement;

public class Microscope : OutLine
{
    protected override void DestinationMarkerSet(object sender, DestinationMarkerEventArgs e)
    {
        SceneManager.LoadScene("Microscope");
    }
}
