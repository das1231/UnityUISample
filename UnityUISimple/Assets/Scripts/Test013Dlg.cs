using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test013Dlg : MonoBehaviour
{
    public Button m_btnResult = null;
    public Button m_btnClear = null;
    public Button m_btnAdd = null;
    public Text m_txtResult = null;
    public Text m_txtAdd = null;
    public InputField m_inpName = null;
    public InputField m_inpKor = null;
    public InputField m_inpEng = null;
    public InputField m_inpMath = null;

    List<Score0> scoreList = new List<Score0>();
    void Start()
    {
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_btnResult.onClick.AddListener(OnClicked_Result);
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_txtAdd.text = "";
        m_txtResult.text = "";
    }

    private void OnClicked_Add()
    {
        m_txtAdd.text = String.Empty;
        Score0 score = new Score0(m_inpName.text, int.Parse(m_inpKor.text), int.Parse(m_inpEng.text), int.Parse(m_inpMath.text));
        scoreList.Add(score);
        for (int i = 0; i < scoreList.Count; i++)
        {
            Score0 temp = scoreList[i];
            m_txtAdd.text += $"{temp.m_name}:{temp.m_kor},{temp.m_eng},{temp.m_math}\n";
        }
        m_inpEng.text = ""; m_inpKor.text = ""; m_inpMath.text = ""; m_inpName.text = "";
    }

    private void OnClicked_Result()
    {
        m_txtResult.text = "[己利包府]\n";
        m_txtResult.text += "======================================================\n";
        for (int i = 0; i < scoreList.Count; i++)
        {
            Score0 temp = scoreList[i];
            m_txtResult.text += $"{temp.m_name}:{temp.m_kor},{temp.m_eng},{temp.m_math} " +
                $"钦拌:{temp.m_sum} 乞闭:{temp.m_avg:F2}\n";
        }
    }

    private void OnClicked_Clear()
    {
        m_txtResult.text = "";
    }
}

public class Score0
{
    public string m_name = string.Empty;
    public int m_kor = 0;
    public int m_eng = 0;
    public int m_math = 0;
    public int m_sum = 0;
    public float m_avg = 0;
    public Score0(string name,int kor,int eng, int math)
    {
        m_name = name;
        m_kor = kor;
        m_eng = eng;
        m_math = math;
        m_sum = kor + eng + math;
        m_avg = (float)m_sum / 3;
    }
}