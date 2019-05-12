using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Highlighters;
using UnityEngine.SceneManagement;

public class OutLine : MonoBehaviour {
    public VRTK_DestinationMarker pointer;
    public Color hoverColor = Color.cyan;
    public Color selectColor = Color.yellow;

    protected virtual void OnEnable()
    {
        pointer = (pointer == null ? GetComponent<VRTK_DestinationMarker>() : pointer);

        if (pointer != null)
        {
            pointer.DestinationMarkerEnter += DestinationMarkerEnter;
            pointer.DestinationMarkerHover += DestinationMarkerHover;
            pointer.DestinationMarkerExit += DestinationMarkerExit;
            pointer.DestinationMarkerSet += DestinationMarkerSet;
        }
        else
        {
            VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTKExample_PointerObjectHighlighterActivator", "VRTK_DestinationMarker", "the Controller Alias"));
        }
    }

    protected virtual void OnDisable()
    {
        if (pointer != null)
        {
            pointer.DestinationMarkerEnter -= DestinationMarkerEnter;
            pointer.DestinationMarkerHover -= DestinationMarkerHover;
            pointer.DestinationMarkerExit -= DestinationMarkerExit;
            pointer.DestinationMarkerSet -= DestinationMarkerSet;
        }
    }

    protected virtual void DestinationMarkerEnter(object sender, DestinationMarkerEventArgs e)
    {
        ToggleHighlight(e.target, hoverColor);
    }

    private void DestinationMarkerHover(object sender, DestinationMarkerEventArgs e)
    {

    }

    protected virtual void DestinationMarkerExit(object sender, DestinationMarkerEventArgs e)
    {
        ToggleHighlight(e.target, Color.clear);

    }

    protected virtual void DestinationMarkerSet(object sender, DestinationMarkerEventArgs e)
    {
        Debug.Log("321123");
        ToggleHighlight(e.target, selectColor);
    }

    protected virtual void ToggleHighlight(Transform target, Color color)
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
