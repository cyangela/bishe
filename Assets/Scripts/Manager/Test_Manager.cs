using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public enum Answer
{
    A,
    B,
    C,
    D
}

public class Test_Manager : MonoBehaviour {

    public static Test_Manager _Instance;
    private void Awake()
    {
        _Instance = this;
    }
    public GameObject[] answer;
    public Text result;

    private Button next_Button;

    private Answer cur_Answer;

    private Animator animator;
    private bool no;

    public void Begin()
    {
        for (int i = 0; i < answer.Length; i++)
        {
            answer[i].GetComponent<Animator>().SetBool("isPlay", true);
        }
    }

    public void Compare(Target target, Animator ani)
    {
        animator = ani;
        Debug.Log(target.num);
        result.gameObject.SetActive(true);
        if (cur_Answer.ToString() == target.num)
        {
            result.text = "正确，请继续！";
            animator.SetBool("isPlay", false);
            Invoke("ReSet", 2);
        }
        else
        {
            result.text = "错误，请重选！";
            animator.SetBool("isPlay", false);
            no = true;
        }
    }

    public void SetAnswer(string answer)
    {
        cur_Answer = (Answer)Enum.Parse(typeof(Answer), answer);
    }

    private void Update()
    {
        if (no)
        {
            AnimatorStateInfo animatorInfo = animator.GetCurrentAnimatorStateInfo(0);
            if ((animatorInfo.normalizedTime > 1.0f) && (animatorInfo.IsName("return")))
            {
                animator.SetBool("isPlay", true);
                no = false;
            }
        }
    }

    public void SetNextButton(Button button)
    {
        next_Button = button;
    }

    private void ReSet()
    {
        next_Button.gameObject.SetActive(true);
        for (int i = 0; i < answer.Length; i++)
        {
            if (answer[i].GetComponent<Animator>().GetBool("isPlay"))
            {
                answer[i].GetComponent<Animator>().SetBool("isPlay", false);
            }
        }
    }
}
