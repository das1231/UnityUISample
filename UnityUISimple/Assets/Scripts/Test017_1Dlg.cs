using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Test017_1Dlg : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;
    [SerializeField] Button m_btnAdd = null;
    [SerializeField] Button m_btnFSave = null;
    [SerializeField] Button m_btnFLoad = null;
    [Header("Text")]
    [SerializeField] Text m_txtList = null;
    [SerializeField] Text m_txtResult = null;
    [Header("InputField")]
    [SerializeField] InputField m_inpName = null;
    [SerializeField] InputField m_inpKor = null;
    [SerializeField] InputField m_inpEng = null;
    [SerializeField] InputField m_inpMath = null;

    List<Score5> m_scoreList = new List<Score5>();
    void Start()
    {
        m_txtList.text = "";
        m_txtResult.text = "";

        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnFSave.onClick.AddListener(OnClicked_FSave);
        m_btnFLoad.onClick.AddListener(OnClicked_FLoad);
    }
    void OnClicked_Clear()
    {
        m_txtResult.text = "";
        m_txtList.text = "";
        m_scoreList.Clear();
        InpClear();
    }
    void OnClicked_Ok()
    {
        m_txtResult.text = "";
        m_scoreList.Sort((a, b) => a.m_Sum < b.m_Sum ? 1 : -1);
        for (int i = 0; i < m_scoreList.Count; i++)
        {
            Score5 scores = m_scoreList[i];
            string kor = Rank(scores.m_Kor);
            string eng = Rank(scores.m_Eng);
            string math = Rank(scores.m_Math);
            string total = Rank(scores.m_Total);
            m_txtResult.text += $"{i + 1}등: {scores.m_Name} {kor} {eng} {math}\t<{total}>\n";
        }
    }
    void OnClicked_Add()
    {
        int scoreKor = int.Parse(m_inpKor.text);
        int scoreEng = int.Parse(m_inpEng.text);
        int scoreMat = int.Parse(m_inpMath.text);
        if (scoreKor > 100 || scoreEng > 100 || scoreMat > 100)
        {
            m_txtList.text = "0~100 사이 숫자를 입력해주세요";
            m_scoreList.Clear();
            return;
        }
        Score5 score = new Score5(m_inpName.text, scoreKor, scoreEng, scoreMat);
        m_scoreList.Add(score);
        PrintList();
        InpClear();
    }

    void OnClicked_FSave()
    {
        StreamWriter sw = new StreamWriter("Test017_1.txt");
        sw.WriteLine(m_scoreList.Count);
        for (int i = 0; i < m_scoreList.Count; i++)
        {
            Score5 scores = m_scoreList[i];
            sw.WriteLine(scores.m_Name);
            sw.WriteLine(scores.m_Kor);
            sw.WriteLine(scores.m_Eng);
            sw.WriteLine(scores.m_Math);
        }
        sw.Close();
    }
    void OnClicked_FLoad()
    {
        m_scoreList.Clear();
        StreamReader sr = new StreamReader("Test017_1.txt");
        int count = int.Parse(sr.ReadLine());
        for (int i = 0; i < count; i++)
        {
            string name = sr.ReadLine();
            int kor = int.Parse(sr.ReadLine());
            int eng = int.Parse(sr.ReadLine());
            int math = int.Parse(sr.ReadLine());
            Score5 scores = new Score5(name, kor, eng, math);
            m_scoreList.Add(scores);
        }
        PrintList();
        sr.Close();
    }
    void PrintList()
    {
        m_txtList.text = "";
        for (int i = 0; i < m_scoreList.Count; i++)
        {
            Score5 score = m_scoreList[i];
            m_txtList.text += $"{score.m_Name} {score.m_Kor} {score.m_Eng} {score.m_Math}\n";
        }
    }
    string Rank(int a)
    {
        string rank = string.Empty;
        switch (a)
        {
            case >= 90:
                {
                    rank = "A";
                    break;
                }
            case >= 80:
                {
                    rank = "B";
                    break;
                }
            case >= 70:
                {
                    rank = "C";
                    break;
                }
            case >= 60:
                {
                    rank = "D";
                    break;
                }
            default:
                {
                    rank = "F";
                }
                break;
        }
        return rank;
    }
    void InpClear()
    {
        m_inpName.text = "";
        m_inpKor.text = "";
        m_inpEng.text = "";
        m_inpMath.text = "";
    }
}
public class Score5
{
    public string m_Name = string.Empty;
    public int m_Kor = 0;
    public int m_Eng = 0;
    public int m_Math = 0;
    public int m_Sum = 0;
    public int m_Total = 0;
    public Score5(string name, int kor, int eng, int math)
    {
        m_Name = name;
        m_Kor = kor;
        m_Eng = eng;
        m_Math = math;
        m_Sum = kor + eng + math;
        m_Total = m_Sum / 3;
    }
}
