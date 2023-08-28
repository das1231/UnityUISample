using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Test004Dlg : MonoBehaviour
{
    public Button m_BtnResult = null;
    public Button m_BtnClear = null;
    public InputField m_Input = null;
    public Text m_Result = null;

    void Start()
    {
        m_BtnResult.onClick.AddListener(BtnResultOnClick);
        m_BtnClear.onClick.AddListener(BtnClearOnClick);

        m_Result.text = "";
    }

    private void BtnClearOnClick()
    {
        m_Result.text = "";
    }

    private void BtnResultOnClick()
    {
        int num = int.Parse(m_Input.text);
        int result = 1;

        for (int i = 1; i < num+1; i++)
        {
            result *= i;
            if (i == num)
                m_Result.text += $"{num}";
            else
                m_Result.text += $"{i}*";
        }

        m_Result.text += $"= {result}";
    }
}

