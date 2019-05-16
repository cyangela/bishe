using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFade : MonoBehaviour
{
    private Color currentColor = new Color(0, 0, 0, 0);
    private Color targetColor = new Color(0, 0, 0, 0);
    private Color deltaColor = new Color(0, 0, 0, 0);
    private bool fadeOverlay = false;
    static Material fadeMaterial = null;
    static int fadeMaterialColorID = -1;

    private static ScreenFade instance;

    public static ScreenFade Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindGameObjectWithTag("MainCamera").AddComponent<ScreenFade>();
            }
            return instance;
        }
    }

    private void Start()
    {
        if (fadeMaterial == null)
        {
            fadeMaterial = new Material(Shader.Find("Custom/Fade"));
            fadeMaterialColorID = Shader.PropertyToID("fadeColor");
        }
    }

    private void OnStartFade(Color newColor, float duration)
    {
        if (duration > 0.0f)
        {
            targetColor = newColor;
            deltaColor = (targetColor - currentColor) / duration;
        }
        else
        {
            currentColor = newColor;
        }
    }

    void OnPostRender()
    {
        if (currentColor != targetColor)
        {
            if (Mathf.Abs(currentColor.a - targetColor.a) < Mathf.Abs(deltaColor.a) * Time.deltaTime)
            {
                currentColor = targetColor;
                deltaColor = new Color(0, 0, 0, 0);
            }
            else
            {
                currentColor += deltaColor * Time.deltaTime;
            }
        }

        if (currentColor.a > 0 && fadeMaterial)
        {
            fadeMaterial.SetColor(fadeMaterialColorID, currentColor);
            fadeMaterial.SetPass(0);
            GL.Begin(GL.QUADS);

            GL.Vertex3(-1, -1, 0);
            GL.Vertex3(1, -1, 0);
            GL.Vertex3(1, 1, 0);
            GL.Vertex3(-1, 1, 0);
            GL.End();
        }
    }

    /// <summary>
    /// 淡入淡出得转场效果
    /// </summary>
    /// <param name="fadeTimer">淡入时间</param>
    public void SceneFade(MyTween myTween, float fadeTimer = 2f)
    {
        StartCoroutine(FadeCoroutine(fadeTimer, myTween));
    }

    IEnumerator FadeCoroutine(float fadeTimer, MyTween myTween)
    {
        OnStartFade(Color.black, fadeTimer);
        yield return new WaitForSeconds(fadeTimer + 0.5f);//这里加0.5s是为了让这个动画看起来更舒服一些
        myTween.HalfCompleteExcute();
        OnStartFade(new Color(0, 0, 0, 0), fadeTimer / 2);
        myTween.IsComplete = true;
        myTween.CompleteExcute();

    }
}
