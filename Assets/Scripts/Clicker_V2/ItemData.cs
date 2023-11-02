using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData 
{
    public string  m_name;
    public int     m_lifeUp;
    public int     m_manaUp;
    public int     m_damageUp;
    public int     m_defenseUp;

   

    public ItemData (string name, int lifeUp, int manaUp, int damageUp, int defenseUp, int expUp, int goldUp)
    {
        m_name      = name;
        m_lifeUp    = lifeUp;
        m_manaUp    = manaUp;
        m_damageUp  = damageUp;
        m_defenseUp = defenseUp;

    }

}
