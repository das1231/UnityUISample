using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Test008Dlg : MonoBehaviour
{
    public Button m_BtnResult = null;
    public Button m_BtnClear = null;
    public Text m_Result = null;

    Dictionary<int, string> dic = new Dictionary<int, string>();
    void Start()
    {
        m_BtnClear.onClick.AddListener(BtnClearOnClick);
        m_BtnResult.onClick.AddListener(BtnResultOnClick);
    }

    private void BtnResultOnClick()
    {
        m_Result.text = "";
        dic.Add(1, "사과");
        dic.Add(2, "배");
        dic.Add(3, "수박");
        m_Result.text += "[Dictionary - KeyValuePair]\n";
        ForEach();
        m_Result.text += "\n\n[값 번경 - key1,key2의 값 변경]\n";
        dic[1] = "맛있는 사과";
        dic[2] = "맛있는 배";
        ForEach();
        m_Result.text += "\n\n[삭제 - Key:1 삭제]\n";
        dic.Remove(1);
        ForEach();
    }

    private void BtnClearOnClick()
    {
        m_Result.text = "";
    }

    void ForEach()
    {
        foreach (KeyValuePair<int, string> item in dic)
        {
            m_Result.text += $"{item.Key}:{item.Value}, ";
        }
    }
}
