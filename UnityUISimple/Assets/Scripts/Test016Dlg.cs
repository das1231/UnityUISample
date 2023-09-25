using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Test016Dlg : MonoBehaviour
{
    public Button m_btnOk = null;
    public Button m_btnClear = null;
    public Button m_btnAdd = null;
    public Button m_btnFileLoad = null;
    public Button m_btnFileSave = null;
    public InputField m_inpName = null;
    public InputField m_inpKor = null;
    public InputField m_inpEng = null;
    public InputField m_inpMath = null;
    public Text m_txtResult = null;
    public Text m_txtList = null;

    List<Score3> scoreList = new List<Score3>();
    void Start()
    {
        m_btnOk.onClick.AddListener(OnClick_Ok);
        m_btnClear.onClick.AddListener(OnClick_Clear);
        m_btnAdd.onClick.AddListener(OnClick_Add);
        m_btnFileLoad.onClick.AddListener(OnClick_FileLoad);
        m_btnFileSave.onClick.AddListener(OnClick_FileSave);
        m_txtList.text = "";
        m_txtResult.text = "";
    }
    private void OnClick_Clear()
    {
        m_txtList.text = "";
        m_txtResult.text = "";
    }
    private void OnClick_Add()
    {
        if (int.Parse(m_inpKor.text) > 100 || int.Parse(m_inpEng.text) > 100 || int.Parse(m_inpMath.text) > 100)
        {
            m_inpName.text = ""; m_inpKor.text = ""; m_inpEng.text = ""; m_inpMath.text = "";
            return;
        }
        Score3 score = new Score3(m_inpName.text, int.Parse(m_inpKor.text), int.Parse(m_inpEng.text), int.Parse(m_inpMath.text));
        scoreList.Add(score);
        m_txtList.text += $"{score.m_Name} {score.m_Kor} {score.m_Eng} {score.m_Math}\n";
        m_inpName.text = ""; m_inpKor.text = ""; m_inpEng.text = ""; m_inpMath.text = "";
    }
    private void OnClick_Ok()
    {
        int kor = 0;
        int eng = 0;
        int math = 0;
        m_txtResult.text += "[己利 包府]";
        m_txtResult.text += "\n=======================\n";
        for (int i = 0; i < scoreList.Count; i++)
        {
            Score3 temp = scoreList[i];
            m_txtResult.text += $"{temp.m_Name}: {temp.m_Kor},{temp.m_Eng},{temp.m_Math} 钦拌:{temp.m_Sum} 乞闭:{temp.m_Total:F2}\n";
            kor += temp.m_Kor;
            eng += temp.m_Eng;
            math += temp.m_Math;
        }
        m_txtResult.text += "\n=======================\n";
        m_txtResult.text += $"({kor},{kor/3}) ({eng},{eng / 3}) ({math},{math / 3})";
    }
    private void OnClick_FileLoad()
    {
        StreamReader sr = new StreamReader("Test016.txt");
        sr.ReadLine();
        int Count = scoreList.Count;
        for (int i = 0; i < scoreList.Count; i++)
        {
            
        }
        sr.Close();
    }
    void OnClick_FileSave()
    {
        StreamWriter sw = new StreamWriter("Test016.txt");
        sw.WriteLine(scoreList.Count);
        for (int i = 0; i < scoreList.Count; i++)
        {
            sw.WriteLine(scoreList[i].m_Name);
            sw.WriteLine(scoreList[i].m_Kor);
            sw.WriteLine(scoreList[i].m_Eng);
            sw.WriteLine(scoreList[i].m_Math);
        }
        sw.Close();
    }
}

public class Score3
{
    public string m_Name = string.Empty;
    public int m_Kor = 0;
    public int m_Eng = 0;
    public int m_Math = 0;
    public float m_Sum = 0;
    public float m_Total = 0;
    public Score3(string name, int kor, int eng, int math)
    {
        m_Name = name;
        m_Kor = kor;
        m_Eng = eng;
        m_Math = math;
        m_Sum = kor + eng + math;
        m_Total = m_Sum / 3;
    }
}
