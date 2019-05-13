using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Highlighters;

public class _3DUIEventBase : MonoBehaviour {

    public VRTK_DestinationMarker pointer;

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
    }

    protected virtual void DestinationMarkerHover(object sender, DestinationMarkerEventArgs e)
    {
    }

    protected virtual void DestinationMarkerExit(object sender, DestinationMarkerEventArgs e)
    {
    }

    protected virtual void DestinationMarkerSet(object sender, DestinationMarkerEventArgs e)
    {
    }

}
