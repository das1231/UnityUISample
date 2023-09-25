using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Test017Dlg : MonoBehaviour
{
    public Button m_btnOk;
    public Button m_btnClear;
    public Button m_btnAdd;
    public Button m_btnFSave;
    public Button m_btnFLoad;
    [Space]
    public Text m_txtList;
    public Text m_txtResult;
    [Space]
    public InputField m_inpName;
    public InputField m_inpKor;
    public InputField m_inpEng;
    public InputField m_inpMath;

    List<Score4> m_scoreList = new List<Score4>();
    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnFLoad.onClick.AddListener(OnClicked_FileLoad);
        m_btnFSave.onClick.AddListener(OnClicked_FileSave);

        m_txtResult.text = "";
        m_txtList.text = "";
    }
    void OnClicked_Clear()
    {
        m_txtResult.text = "";
        m_txtList.text = "";
        inpClear();
        m_scoreList.Clear();
    }
    void OnClicked_Add()
    {
        Score4 scores = new Score4(m_inpName.text, int.Parse(m_inpKor.text), int.Parse(m_inpEng.text), int.Parse(m_inpMath.text));
        m_scoreList.Add(scores);
        PrintList();
        inpClear();
    }
    void PrintList()
    {
        m_txtList.text = "";
        for (int i = 0; i < m_scoreList.Count; i++)
        {
            Score4 scores = m_scoreList[i];
            m_txtList.text += $"{scores.m_Name}: {scores.m_Kor} {scores.m_Eng} {scores.m_Math}\n";
        }
    }
    void inpClear()
    {
        m_inpName.text = "";
        m_inpKor.text = "";
        m_inpEng.text = "";
        m_inpMath.text = "";
    }
    void OnClicked_Ok()
    {
        m_txtResult.text = "";
        m_scoreList.Sort((a, b) => a.m_Sum < b.m_Sum ? 1 : -1);
        for (int i = 0; i < m_scoreList.Count; i++)
        {
            Score4 temp = m_scoreList[i];
            string kor = Rank(temp.m_Kor);
            string eng = Rank(temp.m_Eng);
            string math = Rank(temp.m_Math);
            string total = Rank(temp.m_Total);
            m_txtResult.text += $"{i + 1}µî: {temp.m_Name} {kor} {eng} {math}\t<{total}>\n";
        }
    }
    void OnClicked_FileSave()
    {
        StreamWriter sw = new StreamWriter("Test017.txt");
        sw.WriteLine(m_scoreList.Count);
        for (int i = 0; i < m_scoreList.Count; i++)
        {
            Score4 score = m_scoreList[i];
            sw.WriteLine(score.m_Name);
            sw.WriteLine(score.m_Kor);
            sw.WriteLine(score.m_Eng);
            sw.WriteLine(score.m_Math);
        }
        sw.Close();
    }
    void OnClicked_FileLoad()
    {
        m_scoreList.Clear();
        StreamReader sr = new StreamReader("Test017.txt");
        int count = int.Parse(sr.ReadLine());
        for (int i = 0; i < count; i++)
        {
            string name = sr.ReadLine();
            int kor = int.Parse(sr.ReadLine());
            int eng = int.Parse(sr.ReadLine());
            int math = int.Parse(sr.ReadLine());
            Score4 score = new Score4(name, kor, eng, math);
            m_scoreList.Add(score);
        }
        PrintList();
        sr.Close();
    }
    string Rank(int score)
    {
        string rank = string.Empty;
        switch (score)
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
}
public class Score4
{
    public string m_Name = string.Empty;
    public int m_Kor;
    public int m_Eng;
    public int m_Math;
    public int m_Sum;
    public int m_Total;
    public Score4(string name, int kor, int eng, int math)
    {
        m_Name = name;
        m_Kor = kor;
        m_Eng = eng;
        m_Math = math;
        m_Sum = kor + eng + math;
        m_Total = m_Sum / 3;
    }
}
