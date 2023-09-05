using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test010Dlg : MonoBehaviour
{
    public Button m_btnResult = null;
    public Button m_btnClear = null;
    public Button btnAdd = null;
    public InputField inputName = null;
    public InputField inputHE = null;
    public Text m_textResult = null;

    List<Animal> animals = new List<Animal>();
    void Start()
    {
        m_btnClear.onClick.AddListener(BtnOnClickClear);
        m_btnResult.onClick.AddListener(BtnOnClickResult);
        btnAdd.onClick.AddListener(BtnOnClickAdd);

        m_textResult.text = "";
    }
    private void BtnOnClickClear()
    {
        m_textResult.text = "";
        animals.Clear();
    }
    private void BtnOnClickAdd()
    {
        string name = inputName.text;
        int he = int.Parse(inputHE.text);
        Animal animal = new Animal(name, he);
        animals.Add(animal);
        inputName.text = "";
        inputHE.text = "";
    }

    private void BtnOnClickResult()
    {
        switch (animals.Count)
        {
            case 1:
                {
                    m_textResult.text = $"{animals[0].name}의 몸무게는 {animals[0].he}입니다";
                    break;
                }
            case 2:
                {
                    m_textResult.text = $"{animals[1].name}, {animals[0].name} 의 몸무게는 {animals[1].he + animals[0].he}입니다.";
                    break;
                }
            default:
                break;
        }
    }
}
public class Animal
{
    public string name;
    public int he;

    public Animal(string a, int b)
    {
        name = a;
        he = b;
    }
}
