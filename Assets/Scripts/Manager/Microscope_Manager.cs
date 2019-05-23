using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRTK.Highlighters;

public class Microscope_Manager : MonoBehaviour
{
    public static Microscope_Manager _Instance;
    private PlayableDirector playableDirector;
	private int index = 0;

    public GameObject canvas;
	public GameObject[] go;
    public string[] str;
    public Text text;

    private void Awake()
    {
        _Instance = this;
    }

    private void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    /// <summary>
    /// 动画暂停
    /// </summary>
    public void Stop()
    {
        playableDirector.Pause();
    }

    /// <summary>
    /// 动画开始
    /// </summary>
    public void Play()
    {
        playableDirector.Play();
    }

	/// <summary>
	/// 设置下一个可操作物体
	/// </summary>
	public void SetNextGO()
	{
        if (index < go.Length)
        {
            if (index == go.Length - 1)
            {
                canvas.SetActive(true);
            }
            index++;
            text.text = str[index - 1];
            go[index - 1].GetComponent<VRTK_OutlineObjectCopyHighlighter>().enabled = false;
            if (index != go.Length)
            {
                go[index].GetComponent<VRTK_OutlineObjectCopyHighlighter>().enabled = true;
            }         
        }
	}
    public void GoToMain()
    {
        GameManager._Instance.currentScenceID = ScenceID.Cell;
        SceneManager.LoadScene("2019");
    }

    public void PlayBGM(int id)
    {
        GameManager._Instance.PlayBGM(id);
    }

    public void PlayEffect(int id)
    {
        GameManager._Instance.PlayEffect(id);
    }
}
