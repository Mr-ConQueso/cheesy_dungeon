using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public string m_name;
    public int m_damage;

    public Weapon(string name, int damage)
    {
        m_name = name;
        m_damage = damage;
    }
}
