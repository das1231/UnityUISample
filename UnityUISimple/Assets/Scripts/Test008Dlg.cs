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
        dic.Add(1, "���");
        dic.Add(2, "��");
        dic.Add(3, "����");
        m_Result.text += "[Dictionary - KeyValuePair]\n";
        ForEach();
        m_Result.text += "\n\n[�� ���� - key1,key2�� �� ����]\n";
        dic[1] = "���ִ� ���";
        dic[2] = "���ִ� ��";
        ForEach();
        m_Result.text += "\n\n[���� - Key:1 ����]\n";
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
