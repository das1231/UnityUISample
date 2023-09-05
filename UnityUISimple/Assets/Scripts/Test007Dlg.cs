using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test007Dlg : MonoBehaviour
{
    public Button m_btnResult = null;
    public Button m_btnClear = null;
    public Button m_btnAdd = null;
    public Text m_textResult = null;
    public Text m_textAdd = null;
    public InputField m_inputT = null;

    List<int> lis = new List<int>();

    void Start()
    {
        m_textAdd.text = "";
        m_textResult.text = "";

        m_btnAdd.onClick.AddListener(BtnAddOnClick);
        m_btnClear.onClick.AddListener(BtnClearOnClick);
        m_btnResult.onClick.AddListener(BtnResultOnClick);
    }

    private void BtnResultOnClick()
    {
        if (lis.Count <= 5)
        {
            lis.Sort();
            //lis.Sort((a, b) =>
            //{
            //    return (a > b ? 1 : -1);
            //});

            //lis.Sort((a, b) => a > b ? 1 : -1);
            //lis.Sort((a, b) => b.CompareTo(a)); //lis.Sort((a, b) => a.CompareTo(b));
            //lis.Reverse();
        }
        else
            return;

        foreach (int item in lis)
        {
            if (lis.Count == 5)
                m_textResult.text += $"{item}, ";
        }
    }
    private void BtnClearOnClick()
    {
        m_textResult.text = "";
        lis.Clear();
        m_inputT.text = "";
        m_textAdd.text = "";
    }
    private void BtnAddOnClick()
    {
        int Addnum = int.Parse(m_inputT.text);
        if (Addnum > 100 || 0 > Addnum)
            return;

        if (lis.Count < 5)
        {
            lis.Add(Addnum);
            m_textAdd.text += $"{Addnum}  ";
        }
    }
}
