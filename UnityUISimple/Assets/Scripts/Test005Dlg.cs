using System;
using UnityEngine;
using UnityEngine.UI;

public class Test005Dlg : MonoBehaviour
{
    public Button m_btnResult = null;
    public Button m_btnResultDic = null;
    public Button m_btnClear = null;
    public Text m_Result = null;

    int[] Temp = { 100, 200, 300 };

    int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_btnClear.onClick.AddListener(BtnClearOnClick);
        m_btnResult.onClick.AddListener(BtnResultOnClick);
        m_btnResultDic.onClick.AddListener(BtnResultSeOnClick);
    }

    private void BtnResultSeOnClick()
    {
        m_Result.text = "";
        Test();
        int[,] Array2 = new int[3,2];
        Array2[0, 0] = 10;
        Array2[0, 1] = 9;
        Array2[1, 0] = 7;
        Array2[1, 1] = 6;
        Array2[2, 0] = 77;
        Array2[2, 1] = 66;
        PrintArray(Array2);
    }

    private void BtnClearOnClick()
    {
        m_Result.text = "";
    }

    private void BtnResultOnClick()
    {
        m_Result.text = "";
        TestFor();
        TestWhile();
        TestDoWhile();
    }

    void Test()
    {
        int[,] Array = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
        m_Result.text += "[2차원 배열]..\n";
        for (int i = 0; i < Array.GetLength(0); i++)
        {
            for (int j = 0; j < Array.GetLength(1); j++)
            {
                m_Result.text += $"array[{i},{j}] = {Array[i, j]}\n";
            }
        }
        m_Result.text += "---------------------------------\n";
    }

    void PrintArray(int[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                m_Result.text += $"array[{i},{j}] = {arr[i, j]}\n";
            }
        }
        m_Result.text += "---------------------------------";
    }

    void TestFor()
    {
        m_Result.text += "[for문 테스트]\n";
        for (int i = 0; i < Temp.Length; i++)
        {
            m_Result.text += $"Temp[{i}] = {Temp[i]}{(i < Temp.Length - 1 ? ", " : "")}";
        }
        m_Result.text += $"\n----------------------------------------------------------------\n";
    }

    void TestWhile()
    {
        m_Result.text += "\n[While문 테스트]\n";
        num = 0;
        while (num < Temp.Length)
        {
            m_Result.text += $"Temp[{num}] = {Temp[num]}{(num < Temp.Length - 1 ? ", " : "")}";
            num++;
        }
        m_Result.text += $"\n----------------------------------------------------------------\n";
    }

    void TestDoWhile()
    {
        m_Result.text += "\n[Do While문 테스트]\n";
        num = 0;
        do
        {
            m_Result.text += $"Temp[{num}] = {Temp[num]}{(num < Temp.Length - 1 ? ", " : "")}";
            num++;
        } while (num < Temp.Length);
        m_Result.text += $"\n----------------------------------------------------------------\n";
    }
}
