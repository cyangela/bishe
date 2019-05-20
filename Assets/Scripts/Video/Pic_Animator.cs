using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Pic_Animator : MonoBehaviour {

    [SerializeField]
    private int m_FrameRate = 30;

    [SerializeField]
    private Image m_Image;

    [SerializeField] 
    private Sprite[] m_AnimTextures;

    private WaitForSeconds m_FrameRateWait;
    private int m_CurrentTextureIndex;
    private bool m_Playing;

    private void Awake()
    {
        m_FrameRateWait = new WaitForSeconds(1f / m_FrameRate);
    }

    void Start ()
    {
        GetPic();
        m_Playing = true;
        StartCoroutine(PlayTextures());
    }

    private IEnumerator PlayTextures()
    {
        while (m_Playing)
        {
            m_Image.sprite = m_AnimTextures[m_CurrentTextureIndex];

            m_CurrentTextureIndex = (m_CurrentTextureIndex + 1) % m_AnimTextures.Length;

            yield return m_FrameRateWait;
        }
    }

    private void GetPic()
    {
        Resources.LoadAll<Sprite>("");
        string[] sr = Directory.GetFiles(Application.dataPath + "/UI/UI_0");
        Debug.Log(sr[0]);
    }
}
