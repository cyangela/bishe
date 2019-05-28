using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using VRTK.Highlighters;

public class CellInformation : MonoBehaviour
{
    public GameObject[] gos;
    public GameObject go;
    public string nam;
    public Sprite pic_Path;
    public string content;

    private Color hoverColor = Color.cyan;
    private Transform des;

    public void ShowOutLine()
    {
        for (int i = 0; i < gos.Length; i++)
        {
            ToggleHighlight(gos[i].transform, hoverColor, true);
            Enable(gos[i].transform, true);
        }
    }

    public void UnlodaOutLine()
    {
        for (int i = 0; i < gos.Length; i++)
        {
            ToggleHighlight(gos[i].transform, Color.clear, true);
            Enable(gos[i].transform, false);
        }
    }

    public void DisPlayInfo()
    {
        des = transform.parent.parent.Find("Description");
        des.Find("Name").GetComponent<Text>().text = nam;
        des.Find("Content").GetComponent<Text>().text = "\u3000\u3000" + content;
        des.Find("Image").GetComponent<Image>().sprite = pic_Path;
    }

    private void ToggleHighlight(Transform target, Color color, bool flag)
    {
        VRTK_BaseHighlighter highligher = (target != null ? target.GetComponentInChildren<VRTK_BaseHighlighter>() : null);
        if (highligher != null)
        {
            highligher.Initialise();
            if (color != Color.clear)
            {
                highligher.Highlight(color, 0.5f);
            }
            else
            {
                highligher.Unhighlight();
            }
        }
    }

    private void Enable(Transform target, bool flag)
    {
        target.GetComponent<RWVR_Cell>().enable = flag;
}

    public void ShowSingleCellQi()
    {
        go.SetActive(false);
        for (int i = 0; i < gos.Length; i++)
        {
            gos[i].GetComponent<Rotate>().enabled = false;
            gos[i].GetComponent<PlayableDirector>().Play();
        }
    }
    public void HideSingleCellQi()
    {
        go.SetActive(true);
        for (int i = 0; i < gos.Length; i++)
        {
            gos[i].GetComponent<Rotate>().enabled = true;
            gos[i].GetComponent<PlayableDirector>().Pause();
            StartCoroutine(tRewind(gos[i].GetComponent<PlayableDirector>()));
        }
    }

    private IEnumerator tRewind(PlayableDirector Director)
    {
        yield return new WaitForSeconds(0.001f * Time.deltaTime);
        Director.time -= 1.0f * Time.deltaTime;  //1.0f是倒带速度
        Director.Evaluate();
        if (Director.time < 0f)
        {
            Director.time = 0f;
            Director.Evaluate();
        }
        else
        {
            StartCoroutine(tRewind(Director));
        }
    }
}
