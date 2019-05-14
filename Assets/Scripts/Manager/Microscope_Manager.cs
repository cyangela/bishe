using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using VRTK.Highlighters;

public class Microscope_Manager : MonoBehaviour
{
    public static Microscope_Manager _Instance;

    private PlayableDirector playableDirector;

	private int index = 0;

	public GameObject[] gameObject;

    private void Awake()
    {
        _Instance = this;
    }

    private void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    public void Stop()
    {
        playableDirector.Stop();
    }
    public void Play()
    {
        playableDirector.Play();
    }

	/// <summary>
	/// 设置下一个可操作物体
	/// </summary>
	public void SetNextGO()
	{
		index++;
		gameObject[index - 1].GetComponent<VRTK_OutlineObjectCopyHighlighter>().enabled = false;
		gameObject[index].GetComponent<VRTK_OutlineObjectCopyHighlighter>().enabled = true;
	}
}
