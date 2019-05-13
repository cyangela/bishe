using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Highlighters;


public class OutLine : _3DUIEventBase
{
    public Color hoverColor = Color.cyan;
    public Color selectColor = Color.yellow;

    protected override void DestinationMarkerEnter(object sender, DestinationMarkerEventArgs e)
    {
        ToggleHighlight(e.target, hoverColor);
    }

    protected override void DestinationMarkerHover(object sender, DestinationMarkerEventArgs e)
    {      
        if (e.target.tag == "InteractionObject")
        {
            GameManager._Instance.isCanToMicroscope = true;
        }
    }

    protected override void DestinationMarkerExit(object sender, DestinationMarkerEventArgs e)
    {
        ToggleHighlight(e.target, Color.clear);
        GameManager._Instance.isCanToMicroscope = false;

    }

    protected override void DestinationMarkerSet(object sender, DestinationMarkerEventArgs e)
    {
        ToggleHighlight(e.target, selectColor);
    }

    private void ToggleHighlight(Transform target, Color color)
    {
        VRTK_BaseHighlighter highligher = (target != null ? target.GetComponentInChildren<VRTK_BaseHighlighter>() : null);
        if (highligher != null)
        {
            highligher.Initialise();
            if (color != Color.clear)
            {
                highligher.Highlight(color);
            }
            else
            {
                highligher.Unhighlight();
            }
        }
    }
}
