using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Highlighters;

public class CellInformation : MonoBehaviour
{
    public GameObject[] gos;
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
        }
    }

    public void UnlodaOutLine()
    {
        for (int i = 0; i < gos.Length; i++)
        {
            ToggleHighlight(gos[i].transform, Color.clear, true);
        }
    }

    public void DisPlayInfo()
    {
        des = transform.parent.parent.Find("Description");
        des.Find("Name").GetComponent<Text>().text = nam;
        des.Find("Content").GetComponent<Text>().text = content;
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
}
