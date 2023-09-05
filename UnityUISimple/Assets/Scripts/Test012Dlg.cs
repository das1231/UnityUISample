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
        Kor korScore = new Kor(int.Parse(m_InputKor.text));
        English engScore = new English(int.Parse(m_InputEnglish.text));
        Math mathScorer = new Math(int.Parse(m_InputMath.text));
        Name myName = new Name(m_InputName.text);
        m_TextResult.text += $"이름:{myName.name} 국어:{korScore.kor},영어:{engScore.english},수학:{mathScorer.math}\n";

        if (300 > Score(korScore.kor, engScore.english, mathScorer.math))
        {
            int score = Score(korScore.kor, engScore.english, mathScorer.math);
            m_TextResult.text += $"합계:{score}, 평균:{Total(score, 3)}";
        }
    }

    int Score(int a, int b, int c)
    {
        return a + b + c;
    }
    float Total(float num, float num2)
    {
        float a = num / num2;
        return a;
    }
}

public class Kor
{
    public int kor;
    public Kor(int num)
    {
        kor = num;
    }
}
public class Math
{
    public int math;
    public Math(int num)
    {
        math = num;
    }
}
public class Name
{
    public string name;
    public Name(string name)
    {
        this.name = name;
    }
}
public class English
{
    public int english;
    public English(int num)
    {
        english = num;
    }
}