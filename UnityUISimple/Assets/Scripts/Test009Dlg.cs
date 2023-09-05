using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Test009Dlg : MonoBehaviour
{
    public Button m_btnResult = null;
    public Button m_btnClear = null;
    public Text m_Result = null;
    
    Actor master = new Master(5000, 100);
    Actor enemy = new Enemy(2000, 200);
    void Start()
    {
        m_btnClear.onClick.AddListener(BtnClearOnClick);
        m_btnResult.onClick.AddListener(BtnResultOnClick);
    }

    private void BtnResultOnClick()
    {
        m_Result.text = "";

        m_Result.text += $"[기본 HP={master.hp}, Attack={master.attack}]\n";
        HPText(master);
        m_Result.text += "[데미지 50 생김]\n";
        master.hp -= 50;
        HPText(master);
        Line();

        m_Result.text += $"[적 HP{enemy.hp},Attack={enemy.attack}으로 설정]\n";
        HPText(enemy);
        m_Result.text += "[적이 마스터에게 공격 당함]\n";
        HPText(Attack(enemy, master));
        Line();

        m_Result.text += "[마스터가 HP 100만큼 힐링이 됨]\n";
        HPText(Heal(master, 100));
        m_Result.text += "[적의 HP 200만큼 힐링이 됨]\n";
        HPText(Heal(enemy, 200));
        Line();
    }

    private void BtnClearOnClick()
    {
        m_Result.text = "";
    }

    Actor Attack(Actor Target,Actor Attaker)
    {
        Target.hp -= Attaker.attack;
        return Target;
    }
    Actor Heal(Actor Target, int heal)
    {
        Target.hp += heal;
        return Target;
    }
    void Line()
    {
        m_Result.text += "-------------------------------------\n";
    }
    void HPText(Actor actor)
    {
        m_Result.text += $"{actor} HP = {actor.hp}\n";
    }
}
