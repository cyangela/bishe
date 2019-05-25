using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// 场景ID
/// </summary>
public enum ScenceID
{
    Start,
    Mian,
    Microscope,
    Cell
}

public class GameManager : MonoBehaviour
{
    public static GameManager _Instance;

    private void Awake()
    {
        _Instance = this;
        DontDestroyOnLoad(this);
    }

    private int current_Part = 0;
    private GameObject[] telePortPoints;//实验室路标

    [HideInInspector]
    public bool isCanToMicroscope;//到显微镜场景

    [HideInInspector]
    public bool isCanTo2019;//到实验室场景

	[HideInInspector]
	public bool isMicroscope;//是否进行显微镜操作

    [HideInInspector]
    public ScenceID currentScenceID = 0;//当前场景ID

    public AudioSource bg_Source;
    public AudioSource effect_Source;

    public AudioClip[] bg_Clips;
    public AudioClip[] effect_Clips;

    /// <summary>
    /// 设置引导路标的可见性
    /// </summary>
    /// <param name="flag"></param>
    public void SetTelePortPoints(bool flag)
    {
        if (currentScenceID == ScenceID.Mian || currentScenceID == ScenceID.Cell)
        {
            telePortPoints = new GameObject[2];
            telePortPoints[0] = GameObject.Find("TelePortPoints").transform.Find("TelePortPoints_1").gameObject;
            telePortPoints[1] = GameObject.Find("TelePortPoints").transform.Find("TelePortPoints_2").gameObject;
            telePortPoints[current_Part].SetActive(flag);
            current_Part++;
        }
    }

    public void PlayBGM(int id)
    {
        if (id < bg_Clips.Length)
        {
            bg_Source.clip = bg_Clips[id];
        }
        else
        {
            bg_Source.clip = bg_Clips[0];
        }
        bg_Source.Play();
    }

    public void PlayEffect(int id)
    {
        if (id < effect_Clips.Length)
        {
            effect_Source.clip = effect_Clips[id];
            effect_Source.Play();
        }      
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
