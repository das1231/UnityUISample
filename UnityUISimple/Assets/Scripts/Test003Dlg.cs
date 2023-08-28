using UnityEngine;
using UnityEngine.UI;

public class Test003Dlg : MonoBehaviour
{
    public Button m_BtnStart = null;
    public Button m_BtnClear = null;
    public InputField m_Num1 = null;
    public InputField m_Num2 = null;
    public InputField m_Num3 = null;
    public Text m_Result = null;

    private void Start()
    {
        m_BtnStart.onClick.AddListener(BtnStartOnClick);
        m_BtnClear.onClick.AddListener(BtnClearOnClick);

        m_Result.text = "";
    }

    private void BtnClearOnClick()
    {
        m_Result.text = "";
    }

    private void BtnStartOnClick()
    {
        int num1 = int.Parse(m_Num1.text);
        int num2 = int.Parse(m_Num2.text);
        int num3 = int.Parse(m_Num3.text);

        if (num2 > num3 && num2 > num1)
            Swap(ref num1, ref num2);

        if (num3 > num1 && num3 > num2)
            Swap(ref num1, ref num3);

        if (num2 < num3)
            Swap(ref num2, ref num3);

        m_Result.text = $"가장 큰 수:{num1}\n {num1}, {num2}, {num3}";
    }
    void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}
