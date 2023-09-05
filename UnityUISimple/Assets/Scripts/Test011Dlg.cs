using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Test011Dlg : MonoBehaviour
{
    public Button m_btnResult = null;
    public Button m_btnClear = null;
    public Button btnAdd = null;
    public InputField inputName = null;
    public InputField inputHP = null;
    public Text m_textResult = null;
    public Text m_textMonster = null;

    public int attack = 80;
    List<Monster> enemys = new List<Monster>();
    void Start()
    {
        m_btnClear.onClick.AddListener(BtnOnClickClear);
        m_btnResult.onClick.AddListener(BtnOnClickResult);
        btnAdd.onClick.AddListener(BtnOnClickAdd);
        m_textMonster.text = "";
        m_textResult.text = "";
    }

    private void BtnOnClickResult()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            m_textResult.text += $"{i+1}.Name = {enemys[i].name}, HP = {(enemys[i].hp - attack > 0 ? enemys[i].hp - attack : 0)}\n";
        }
    }

    private void BtnOnClickAdd()
    {
        string Name = inputName.text;
        int Hp = int.Parse(inputHP.text);
        Monster monster = new Monster(Name, Hp);
        enemys.Add(monster);
        m_textMonster.text += $"({monster.name},{monster.hp}),";
        inputHP.text = "";
        inputName.text = "";
    }

    private void BtnOnClickClear()
    {
        m_textResult.text = "";
        inputHP.text = "";
        inputName.text = "";
    }
}

public class Monster
{
    public string name;
    public int hp;
    public Monster(string name,int hp)
    {
        this.name = name;
        this.hp = hp;
    }
}