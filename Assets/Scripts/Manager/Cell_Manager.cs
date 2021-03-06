﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

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

    public PlayableDirector playableDirector;

    public PlayableDirector he;
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

    public void ReturnClicks()
    {
        if (cell)
        {
            cell.UnlodaOutLine();
            cell.HideSingleCellQi();
            cell = null;
        }
    }

    public void ShowSingleCellQi(CellInformation cl)
    {
        this.cell = cl;
        cell.ShowOutLine();
        cell.DisPlayInfo();
        cell.ShowSingleCellQi();
    }

    public void GoToTest()
    {
        GameManager._Instance.PlayEffect(1);
        SceneManager.LoadScene("Test");
    }

    public void PlayBGM(int id)
    {
        GameManager._Instance.PlayBGM(id);
    }

    public void PlayEffect(int id)
    {
        GameManager._Instance.PlayEffect(id);
    }

    public void Play()
    {
        playableDirector.Play();
    }
    public void Pause()
    {
        playableDirector.Pause();
    }

    public void HePlay()
    {
        he.Play();
    }
}
