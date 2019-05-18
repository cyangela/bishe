using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellQi
{
    XiBaoMo,
    XiBaoHe,
    XianLiTi,
    GaoErJiTi,
    HeTangTi,
    NeiZhiWang,
    RongMeiTi,
    ZhongXinTi,
    YePao,
    XiBaoBi,
    YeLvTi
}

public class Cell_Manager : MonoBehaviour
{
    public static Cell_Manager _Instance;
    private void Awake()
    {
        _Instance = this;
    }

    public CellQi cur_cellQi;

    private CellInformation cell;

    public void CellOnclik(CellInformation cl)
    {
        this.cell = cl;
        cell.ShowOutLine();
        cell.DisPlayInfo();
    }

    public void ReturnClick()
    {
        if (cell)
        {
            cell.UnlodaOutLine();
            cell = null;
        }
    }

}
