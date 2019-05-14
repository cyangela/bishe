using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 继承 拖拽接口
/// </summary>
public class SliderEvent : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]
    public ToPlayVideo toPlayVideo;        // 视频播放的脚本

    /// <summary>
    /// 给 Slider 添加开始拖拽事件
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        toPlayVideo.DragEvent(true);
        toPlayVideo.SetVideoTimeValueChange();
    }

    /// <summary>
    /// 给 Slider 添加结束拖拽事件
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        toPlayVideo.DragEvent(false);
    }
}