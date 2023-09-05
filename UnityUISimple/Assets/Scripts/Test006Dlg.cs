using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test006Dlg : MonoBehaviour
{
    public Button m_btnResult = null;
    public Button m_btnClear = null;
    public Text m_Result = null;
    void Start()
    {
        m_btnClear.onClick.AddListener(BtnClearOnClick);
        m_btnResult.onClick.AddListener(BtnResultOnClick);
    }

    private void BtnResultOnClick()
    {
        m_Result.text = "";
        ListFor();
        m_Result.text += "\n-----------------------------------\n";
        ListForeach();
    }

    private void BtnClearOnClick()
    {
        m_Result.text = "";
    }

    void ListFor()
    {
        List<int> nums = new List<int>();
        nums.Add(10);
        nums.Add(20);
        nums.Add(30);
        m_Result.text += "리스트 - for\n";
        for (int i = 0; i < nums.Count; i++)
        {
            m_Result.text += $"[{i}]: {nums[i]}, ";
        }
    }

    void ListForeach()
    {
        List<int> nums = new List<int>();
        nums.Add(10);
        nums.Add(20);
        nums.Add(30);
        nums.Add(40);
        nums.Add(50);

        m_Result.text += "리스트 - foreach\n";
        ForEach(nums);
        m_Result.text += "\n-----------------------------------\n";

        nums.Remove(40);
        nums.RemoveAt(0);
        m_Result.text += "리스트 삭제 - foreach\n";
        ForEach(nums);
    }

    void ForEach(List<int> nums)
    {
        foreach (int num in nums)
        {
            m_Result.text += $"{num},";
        }
    }
}
