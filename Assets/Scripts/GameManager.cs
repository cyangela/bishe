using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _Instance;

    private void Awake()
    {
        _Instance = this;
        DontDestroyOnLoad(this);
    }

    private int current_Part = 0;
    private GameObject[] telePortPoints;

    [HideInInspector]
    public bool isCanToMicroscope;

    [HideInInspector]
    public bool isCanTo2019;

    private void Start()
    {

    }

    /// <summary>
    /// 设置引导路标的可见性
    /// </summary>
    /// <param name="flag"></param>
    public void SetTelePortPoints(bool flag)
    {
        telePortPoints = new GameObject[2];
        telePortPoints[0] = GameObject.Find("TelePortPoints").transform.Find("TelePortPoints_1").gameObject;
        telePortPoints[current_Part].SetActive(flag);
    }
}
