using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapData
{
    public string m_name;
    public int m_playerDamage;
    public int m_manaDamage;
    public int m_armorReduction;
    public int m_attackReduction;

    public TrapData(string name, int playerDamage, int manaDamage, int armorReduction, int attackReduction)
    {
        m_name = name;
        m_playerDamage = playerDamage;
        m_manaDamage = manaDamage;
        m_armorReduction = armorReduction;
        m_attackReduction = attackReduction;


    }
}
