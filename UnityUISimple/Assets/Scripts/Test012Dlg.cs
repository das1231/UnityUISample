using UnityEngine;
using UnityEngine.UI;

public class Test012Dlg : MonoBehaviour
{
    public InputField m_InputName = null;
    public InputField m_InputKor = null;
    public InputField m_InputMath = null;
    public InputField m_InputEnglish = null;
    public Button m_BtnResult = null;
    public Button m_BtnClear = null;
    public Text m_TextResult = null;
    public void Start()
    {
        m_BtnResult.onClick.AddListener(BtnResultOnClick);
        m_BtnClear.onClick.AddListener(BtnClearOnClick);
    }

    private void BtnClearOnClick()
    {
        m_TextResult.text = "";
    }

    private void BtnResultOnClick()
    {
        m_TextResult.text = "";
        Score score = new Score(int.Parse(m_InputKor.text), int.Parse(m_InputMath.text),
            int.Parse(m_InputEnglish.text), (m_InputName.text));
        m_TextResult.text += $"이름:{score.name} 국어:{score.kor},영어:{score.english},수학:{score.math}\n";

        if (300 > Sum(score.kor, score.english, score.math))
        {
            int sumnum = Sum(score.kor, score.english, score.math);
            m_TextResult.text += $"합계:{sumnum}, 평균:{Total(sumnum, 3)}";
        }
    }

    int Sum(int a, int b, int c)
    {
        return a + b + c;
    }
    float Total(float num, float num2)
    {
        float a = num / num2;
        return a;
    }
}

public class Score
{
    public int kor;
    public int math;
    public string name;
    public int english;
    public Score(int kor,int math,int eng,string name)
    {
        this.kor = kor;
        this.math = math;
        english = eng;
        this.name = name;
    }
}