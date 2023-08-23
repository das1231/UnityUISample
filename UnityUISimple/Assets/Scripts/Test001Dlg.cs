using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test001Dlg: MonoBehaviour
{
    public Text m_Result = null;
    public Button m_btnOK = null;
    public Button m_btnClear = null;

    int a = 100;
    int b = 200;

    void Start()
    {
        m_btnOK.onClick.AddListener(OnClicked_OK);
        m_btnClear.onClick.AddListener(OnClicked_Clear);

        m_Result.text = "";
    }

    private void OnClicked_Clear()
    {
        m_Result.text = "";
    }

    private void OnClicked_OK()
    {
        int sum = Sum(10, 20);
        m_Result.text = String.Format("гу╟Х = {0}\n",sum);
        m_Result.text += "=========================\n\n";
        m_Result.text += $"a = {a},b = {b}\n";
        Swap(a, b);
        m_Result.text += String.Format("a = {0}, b = {1}\n", a, b);
        Swap(ref a, ref b);
        m_Result.text += String.Format("a = {0}, b = {1}\n", a, b);
        m_Result.text += "=========================\n";
    }

    int Sum(int a, int b)
    {
        int result = a + b;
        return result;
    }

    void Swap(int a, int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}
