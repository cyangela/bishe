﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderEvent : MonoBehaviour, IDragHandler, IEndDragHandler
{

    [SerializeField]
    public ToPlayVideo toPlayVideo;
    /// <summary>
    /// 给 Slider 添加开始拖拽事件
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        toPlayVideo.videoPlayer.Pause();
        SetVideoTimeValueChange();
    }

    /// <summary>
    /// 当前的 Slider 比例值转换为当前的视频播放时间
    /// </summary>
    private void SetVideoTimeValueChange()
    {
        toPlayVideo.videoPlayer.time = toPlayVideo.videoTimeSlider.value * toPlayVideo.videoPlayer.clip.length;
    }

    /// <summary>
    /// 给 Slider 添加结束拖拽事件
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        toPlayVideo.videoPlayer.Play();
    }

}
