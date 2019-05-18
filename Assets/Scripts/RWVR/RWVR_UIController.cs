using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RWVR_UIController : RWVR_InteractionObject
{
    [Header("显示的游戏物体")]
    public GameObject[] gos_On;
    [Header("隐藏的游戏物体")]
    public GameObject[] gos_Off;
    [Header("Toggle物体")]
    public GameObject gos_Toggle;
    [Header("细胞器")]
    public bool isCellQi;
    [Header("关闭旋转模式")]
    public bool is_Off;
    [Header("动植物细胞")]
    public Rotate[] rotate;
    [Header("返回按钮")]
    public bool go_Return;


    public override void OnTriggerWasPressed(RWVR_InteractionController controller)
    {
        for (int i = 0; i < gos_Off.Length; i++)
        {
            gos_Off[i].SetActive(false);
        }
        for (int i = 0; i < gos_On.Length; i++)
        {
            gos_On[i].SetActive(true);
        }
        if (gos_Toggle)
        {
            gos_Toggle.GetComponent<Toggle>().isOn = !gos_Toggle.GetComponent<Toggle>().isOn;
        }
        if (isCellQi)
        {
            Cell_Manager._Instance.CellOnclik(GetComponent<CellInformation>());
        }
        if (is_Off)
        {
            for (int i = 0; i < rotate.Length; i++)
            {
                rotate[i].SelfRotate(false);
            }
        }
        if (go_Return)
        {
            Cell_Manager._Instance.ReturnClick();
        }
    }
 }
