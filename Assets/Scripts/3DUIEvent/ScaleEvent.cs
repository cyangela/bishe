using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using VRTK;


public class ScaleEvent : _3DUIEventBase
{
    private Vector3 vector3;

    protected override void DestinationMarkerEnter(object sender, DestinationMarkerEventArgs e)
    {
        SetScale(e.target, 1.06f);
    }

    //protected override void DestinationMarkerHover(object sender, DestinationMarkerEventArgs e)
    //{
    //    if (e.target.tag == "InteractionObject")
    //    {
    //        GameManager._Instance.isCanTo2019 = true;
    //    }
    //}

    protected override void DestinationMarkerExit(object sender, DestinationMarkerEventArgs e)
    {
        ReSetScale(e.target);
    }

    protected override void DestinationMarkerSet(object sender, DestinationMarkerEventArgs e)
    {
        if (e.target.name == "Video")
        {
            VideoPlayer videoPlayer = e.target.GetComponent<VideoPlayer>();
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
            }
            else
            {
                videoPlayer.Play();
            }
        }
        else
        {

        }
    }

    private void SetScale(Transform target, float scale)
    {
        if (target.tag == "Start_3D_UI")
        {
            vector3 = target.localPosition;
            target.Translate(0, 0, -scale);
            if (target.name != "Video")
            {
                GameManager._Instance.isCanTo2019 = true;
            }
            //target.localScale = new Vector3(target.localScale.x * scale, target.localScale.y * scale, target.localScale.z);
        }
        
    }

    private void ReSetScale(Transform target)
    {
        if (target.tag == "Start_3D_UI")
        {
            target.localPosition = vector3;
            GameManager._Instance.isCanTo2019 = false;
            //target.localScale = Vector3.one;
        }      
    }
}
