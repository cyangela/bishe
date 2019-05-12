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
    public GameObject[] telePortPoints;

    private void Start()
    {

    }

    /// <summary>
    /// 设置引导路标的可见性
    /// </summary>
    /// <param name="flag"></param>
    public void SetTelePortPoints(bool flag)
    {
        Debug.Log(current_Part);
        telePortPoints[current_Part].SetActive(flag);
    }
}
