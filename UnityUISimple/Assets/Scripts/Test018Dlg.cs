using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Test018Dlg : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] Button m_btnOk = null;
    [SerializeField] Button m_btnClear = null;
    [SerializeField] Button m_btnAdd = null;
    [SerializeField] Button m_btnFSave = null;
    [SerializeField] Button m_btnFLoad = null;
    [SerializeField] Button m_btnFind = null;
    [Header("Text")]
    [SerializeField] Text m_txtResult = null;
    [Header("InputField")]
    [SerializeField] InputField m_inpName;
    [SerializeField] InputField m_inpNum;
    [SerializeField] InputField m_inpReg;
    [SerializeField] InputField m_inpFind;
    List<Student> studList = new List<Student>();
    void Start()
    {
        m_btnOk.onClick.AddListener(OnClicked_Ok);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_btnAdd.onClick.AddListener(OnClicked_Add);
        m_btnFSave.onClick.AddListener(OnClicked_FSave);
        m_btnFLoad.onClick.AddListener(OnClicked_FLoad);
        m_btnFind.onClick.AddListener(OnClicked_Find);

        m_txtResult.text = "";
    }
    private void OnClicked_Clear()
    {
        m_txtResult.text = "";
        studList.Clear();
        m_inpName.text = "";
        m_inpNum.text = "";
        m_inpReg.text = "";
    }
    private void OnClicked_Ok()
    {
        PrintList(studList);
    }
    private void OnClicked_Add()
    {
        Student stu = new Student(m_inpName.text, m_inpNum.text, m_inpReg.text);
        studList.Add(stu);
        m_inpName.text = "";
        m_inpNum.text = "";
        m_inpReg.text = "";
    }
    void OnClicked_Find()
    {
        List<Student> containName = new List<Student>();
        for (int i = 0; i < studList.Count; i++)
        {
            if (studList[i].m_Name.Contains(m_inpFind.text))
            {
                Student stu = studList[i];
                containName.Add(stu);
            }
        }
        PrintList(containName);
        m_inpFind.text = "";
    }

    void PrintList(List<Student> lis)
    {
        lis = lis.OrderBy(x => x.m_Name).ToList();

        m_txtResult.text = "";
        txtLine();
        m_txtResult.text += "\n순번  이름\t 전화 \t \t 도시\n";
        txtLine();
        for (int i = 0; i < lis.Count; i++)
        {
            Student stu = lis[i];
            m_txtResult.text += $"\n{i + 1}\t {stu.m_Name}\t\t {stu.m_Num} {stu.m_Reg}\n";
            txtLine();
        }
    }

    void txtLine()
    {
        m_txtResult.text += "---------------------------------------------";
    }

    void OnClicked_FSave()
    {
        StreamWriter sw = new StreamWriter("Test018.txt");
        sw.WriteLine(studList.Count);
        for (int i = 0; i < studList.Count; i++)
        {
            Student stu = studList[i];
            sw.WriteLine(stu.m_Name);
            sw.WriteLine(stu.m_Num);
            sw.WriteLine(stu.m_Reg);
        }
        sw.Close();
    }
    void OnClicked_FLoad()
    {
        studList.Clear();
        StreamReader sr = new StreamReader("Test018.txt");
        int count = int.Parse(sr.ReadLine());
        for (int i = 0; i < count; i++)
        {
            string name = sr.ReadLine();
            string num = sr.ReadLine();
            string reg = sr.ReadLine();
            Student temp = new Student(name, num, reg);
            studList.Add(temp);
        }
        PrintList(studList);
        sr.Close();
    }
}
public class Student
{
    public string m_Name = string.Empty;
    public string m_Num = string.Empty;
    public string m_Reg = string.Empty;
    public Student(string name, string num, string reg)
    {
        m_Name = name;
        m_Num = num;
        m_Reg = reg;
    }
}
