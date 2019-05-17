using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PrintWord1 : MonoBehaviour
{ 
    public string str;
    public float time = 0.05f;
    public int warp;
    public GameObject button;
    private Text text;
    private StringBuilder sb = new StringBuilder();
    private int count = 0;
        
    void Start ()
    {
        text = GetComponent<Text>();
        StartCoroutine(Words(time, warp));
    }

    void Update ()
    {
        text.text = sb.ToString();
    }

    /// <summary>
    /// 打字机
    /// </summary>
    /// <param name="time">时间间隔</param>
    /// <param name="wrap">换行字数</param>
    /// <returns></returns>
    IEnumerator Words(float time, int wrap)
    {
        if (wrap == 0)
            sb = new StringBuilder();
        else
            sb = new StringBuilder("\u3000\u3000");

        for (int i = 0; i < str.Length; i++)
        {
            if (sb.Length <= str.Length + count)
            {
                sb.Append(str[i]);
                if (wrap != 0)
                {
                    if ((sb.Length - count) % wrap == 0)
                    {
                        sb.Append("\r\n");
                        count += 2;
                    }
                }
                yield return new WaitForSeconds(time);
            }
        }
        sb.Append("。");
        yield return new WaitForSeconds(1);
        button.gameObject.SetActive(true);
    }

}
