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
        ToggleHighlight(e.target, hoverColor, true);
    }

  //  protected override void DestinationMarkerHover(object sender, DestinationMarkerEventArgs e)
  //  {      
  //      if (e.target.tag == "InteractionObject")
  //      {
  //          GameManager._Instance.isCanToMicroscope = true;
  //      }

		//if (e.target.tag == "Microscope")
		//{

		//}
  //  }

    protected override void DestinationMarkerExit(object sender, DestinationMarkerEventArgs e)
    {
        ToggleHighlight(e.target, Color.clear, false);
    }

    protected override void DestinationMarkerSet(object sender, DestinationMarkerEventArgs e)
    {
        //ToggleHighlight(e.target, selectColor);
    }

    private void ToggleHighlight(Transform target, Color color, bool flag)
    {
        VRTK_BaseHighlighter highligher = (target != null ? target.GetComponentInChildren<VRTK_BaseHighlighter>() : null);
        //VRTK_BaseHighlighter highligher = target.GetComponentInChildren<VRTK_BaseHighlighter>();
        if (highligher != null && highligher.enabled)
        {
			if (target.tag == "InteractionObject")
			{
				GameManager._Instance.isCanToMicroscope = flag;
			}

			if (target.tag == "Microscope")
			{
				GameManager._Instance.isMicroscope = flag;
			}
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
