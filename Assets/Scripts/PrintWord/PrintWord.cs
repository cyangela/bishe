using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PrintWord : MonoBehaviour
{ 
    public string[] str;
    public float time = 0.05f;
    public int warp;
    private Button button;
    private Text text;
    private StringBuilder sb = new StringBuilder();
    private int count = 0;
    private int index = 0;
        
    void Start ()
    {
        button = transform.parent.Find("Next_Button").GetComponent<Button>();
        button.onClick.AddListener(Onclick);
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

        for (int i = 0; i < str[index].Length; i++)
        {
            if (sb.Length <= str[index].Length + count)
            {
                sb.Append(str[index][i]);
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

    private void Onclick()
    {
        count = 0;
        if (index + 1 == str.Length)
        {
            GameManager._Instance.SetTelePortPoints(true);
            return;
        }
        index++;
        StartCoroutine(Words(time, warp));
    }
    
}
