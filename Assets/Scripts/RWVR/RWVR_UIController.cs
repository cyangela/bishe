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
    [Header("分裂返回按钮")]
    public bool go_Returns;
    [Header("细胞器分裂")]
    public bool isCellSplit;
    [Header("进行测试")]
    public bool isGotoTest;
    [Header("有丝分裂")]
    public bool isFenlie;
    [Header("细胞核变大")]
    public bool isHe;

    public override void OnTriggerWasPressed(RWVR_InteractionController controller)
    {
        GameManager._Instance.PlayEffect(3);

        if (isGotoTest)
        {
            Cell_Manager._Instance.GoToTest();
        }

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
        if (isCellSplit)
        {
            Cell_Manager._Instance.ShowSingleCellQi(GetComponent<CellInformation>());
        }
        if (go_Returns)
        {
            Cell_Manager._Instance.ReturnClicks();
        }
        if (isFenlie)
        {
            Cell_Manager._Instance.Play();
        }
        if (isHe)
        {
            Cell_Manager._Instance.HePlay();
            isHe = false;
            isFenlie = true;
        }
    }
 }
