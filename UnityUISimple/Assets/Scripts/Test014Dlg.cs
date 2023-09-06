using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Test014Dlg : MonoBehaviour
{
    public Button m_btnOk = null;
    public Button m_btnClear = null;
    public Button m_btnAdd = null;
    public Text m_txtResult = null;
    public Text m_txtList = null;
    public InputField m_inpName = null;
    public InputField m_inpKor = null;
    public InputField m_inpEng = null;
    public InputField m_inpMath = null;

    List<Score1> scoreList = new List<Score1>();
    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnClear.onClick.AddListener(OnClicked_Clear);

        m_txtList.text = "";
        m_txtResult.text = "";
    }

    private void OnClicked_Clear()
    {
        m_txtResult.text = "";
    }

    private void OnClicked_Add()
    {
        Score1 score = new Score1(m_inpName.text, int.Parse(m_inpKor.text), int.Parse(m_inpEng.text), int.Parse(m_inpMath.text));
        scoreList.Add(score);
        m_txtList.text += $"{score.m_Name}:{score.m_Kor},{score.m_Eng},{score.m_Math}\n";
        m_inpEng.text = ""; m_inpKor.text = ""; m_inpMath.text = ""; m_inpName.text = "";
    }

    private void OnClicked_Ok()
    {
        float kor = 0;
        float eng = 0;
        float math = 0;
        m_txtResult.text += "\n성적관리\n";
        m_txtResult.text += "======================================\n";
        for (int i = 0; i < scoreList.Count; i++)
        {
            Score1 temp = scoreList[i];
            m_txtResult.text += $"{temp.m_Name}:{temp.m_Kor},{temp.m_Eng},{temp.m_Math} 합계:{temp.m_Sum} 평균:{temp.m_Avg:F2}\n";
            kor += temp.m_Kor;
            eng += temp.m_Eng;
            math += temp.m_Math;
        }
        m_txtResult.text += $"[과목별합계] \n국어:({kor},{kor / scoreList.Count:F2}) \n영어:({eng},{eng / scoreList.Count:F2}) \n수학:({math},{math / scoreList.Count:F2})";
    }
}
public class Score1
{
    public string m_Name = string.Empty;
    public int m_Kor = 0;
    public int m_Eng = 0;
    public int m_Math = 0;
    public int m_Sum = 0;
    public float m_Avg = 0;

    public Score1(string name, int kor, int eng, int math)
    {
        m_Name = name;
        m_Kor = kor;
        m_Eng = eng;
        m_Math = math;
        m_Sum = kor + eng + math;
        m_Avg = (float)m_Sum / 3;
    }
}