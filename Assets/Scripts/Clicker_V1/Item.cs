using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string m_name;
    public int m_lifeUp;
    public int m_manaUp;
    public int m_damageUp;
    public int m_defenseUp;
    public int m_expUp;
    public int m_goldUp;
    public Weapon m_weapon;
    public Shield m_shield;

    public Item(string name, int lifeUp, int manaUp, int damageUp, int defenseUp, int expUp, int goldUp)
    {
        m_name = name;
        m_lifeUp = lifeUp;
        m_manaUp = manaUp;
        m_damageUp = damageUp;
        m_defenseUp = defenseUp;
        m_expUp = expUp;
        m_goldUp = goldUp;
    }

    /*
    public Item(Weapon weapon)
    {

    }

    public Item(Shield shield)
    {

    }
    */

    public void DrawItem()
    {
        Debug.Log(" Has elegido la caja sorpresa, su contenido es... otra caja sorpresa! y un " + m_name);
        Debug.Log(" Te modifica la vida en " + m_lifeUp);
        Debug.Log(" Te modifica el mana en " + m_manaUp);
        Debug.Log(" Te modifica el daño en " + m_damageUp);
        Debug.Log(" Te modifica la defensa en " + m_defenseUp);
        Debug.Log(" Te modifica la experiencia en " + m_expUp);
        Debug.Log(" Te modifica el oro en " + m_goldUp);
    }

}
