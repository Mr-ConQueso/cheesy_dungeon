using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap
{
    public string m_name;
    public int m_playerDamage;
    public int m_manaDamage;

    public Trap(string name, int playerDamage, int manaDamage)
    {
        m_name = name;
        m_playerDamage = playerDamage;
        m_manaDamage = manaDamage;
    }

    public void ActionTrap()
    {
        Debug.Log("Es una trampa! Jehova en latin se escribe con Y!");
        Debug.Log(" Te modifica la vida en " + m_playerDamage);
        Debug.Log(" Te modifica el mana en " + m_manaDamage);
    }
}
