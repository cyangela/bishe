
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
    }
 }
