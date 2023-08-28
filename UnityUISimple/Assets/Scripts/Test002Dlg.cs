using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Test002Dlg : MonoBehaviour
{
    public Button m_BtnOkIf = null;
    public Button m_BtnClear = null;
    public Button m_BtnOkSw = null;
    public Text m_TxtResult = null;
    public InputField m_input = null;

    void Start()
    {
        m_BtnOkIf.onClick.AddListener(OnClickBtnOKIf);
        m_BtnClear.onClick.AddListener(OnClickBtnClear);
        m_BtnOkSw.onClick.AddListener(OnClickBtnOKSW);

        m_TxtResult.text = "";
    }

    private void OnClickBtnOKSW()
    {
        int score = int.Parse(m_input.text);
        if (100 < score || score < 0) return;
        m_TxtResult.text = ScoreSW(score);
    }

    private void OnClickBtnClear()
    {
        m_TxtResult.text = "";
        m_input.text = "";
    }

    private void OnClickBtnOKIf()
    {
        
        int score = int.Parse(m_input.text);
        if (100 < score || score < 0) return;
        m_TxtResult.text = ScoreIF(score);
        
    }
    string ScoreIF(int score)
    {
        string rank = string.Empty;

        if (score >= 90)
            rank = "A";
        else if (score >= 80)
            rank = "B";
        else if (score >= 70)
            rank = "C";
        else if (score >= 60)
            rank = "D";
        else
            rank = "F";
        return $"당신의 점수는 {score} 이므로 {rank}입니다.(IF)";
    }

    string ScoreSW(int score)
    {
        string rank = string.Empty;
        switch (score/10)
        {
            case 10: case 9:
                rank = "A";
                break;
            case int when score/10 >= 8:
                rank = "B";
                break;
            case >= 7:
                rank = "C";
                break;
            case 6:
                rank = "D";
                break;
            default:
                rank = "F";
                break;
        }
        return $"당신의 점수는 {score} 이므로 {rank}입니다.(SW)";
    }
}
