using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test014_1Dlg : MonoBehaviour
{
    public Button m_BtnOk = null;
    public Button m_BtnClear = null;
    public Button m_BtnAdd = null;
    public Text m_TxtResult = null;
    public Text m_TxtInpList = null;
    public InputField m_InpName = null;
    public InputField m_InpKor = null;
    public InputField m_InpMath = null;
    public InputField m_InpEng = null;

    List<Score2> scoreList = new List<Score2>();
    void Start()
    {
        m_BtnAdd.onClick.AddListener(OnClick_Add);
        m_BtnOk.onClick.AddListener(OnClick_Ok);
        m_BtnClear.onClick.AddListener(OnClick_Clear);
        m_TxtInpList.text = "";
        m_TxtResult.text = "";
    }

    private void OnClick_Clear()
    {
        scoreList.Clear();
    }

    private void OnClick_Ok()
    {
        List<Score2> tempList = scoreList;
        float kor = 0;
        float eng = 0;
        float math = 0;
        tempList.Sort((a, b) => a.m_Sum < b.m_Sum ? 1 : -1);
        for (int i = 0; i < tempList.Count; i++)
        {
            Score2 temp = tempList[i];
            m_TxtResult.text += $"{i+1}. 이름:{temp.m_Name} 국어 {temp.m_Kor} " +
                $"수학 {temp.m_Math} 영어 {temp.m_Eng} 합계 {temp.m_Sum} 평균 {temp.m_Total:F2}\n";
            kor += temp.m_Kor;
            eng += temp.m_Eng;
            math += temp.m_Math;
        }
        m_TxtResult.text += "=======================\n[과목 합계,평균]";
        m_TxtResult.text += $"\n국어:({kor}, {kor / tempList.Count:F2})\n수학:({math}, {math / tempList.Count:F2})" +
            $"\n영어:({eng}, {eng / tempList.Count:F2})";
    }

    private void OnClick_Add()
    {
        if (int.Parse(m_InpKor.text) > 100 || int.Parse(m_InpMath.text) > 100 || int.Parse(m_InpEng.text) > 100)
        {
            m_InpName.text = ""; m_InpKor.text = ""; m_InpEng.text = ""; m_InpMath.text = "";
            return;
        }

        Score2 score = new Score2(m_InpName.text, int.Parse(m_InpKor.text), int.Parse(m_InpMath.text), int.Parse(m_InpEng.text));
        scoreList.Add(score);
        m_TxtInpList.text += $"({score.m_Name},{score.m_Kor},{score.m_Math}.{score.m_Eng})\n";
        m_InpName.text = ""; m_InpKor.text = ""; m_InpEng.text = ""; m_InpMath.text = "";
    }
}

public class Score2
{
    public string m_Name = string.Empty;
    public int m_Kor = 0;
    public int m_Eng = 0;
    public int m_Math = 0;
    public float m_Sum = 0;
    public float m_Total = 0;
    public Score2(string name, int kor, int math, int eng)
    {
        m_Name = name;
        m_Kor = kor;
        m_Math = math;
        m_Eng = eng;
        m_Sum = kor + math + eng;
        m_Total = m_Sum / 3;
    }
}
