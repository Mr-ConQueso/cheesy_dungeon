using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[System.Serializable]
public class SpriteSelector : MonoBehaviour
{
    public List<NameSpriteTupla> m_enemySpriteTupla;
    public List<NameSpriteTupla> m_trapSpriteTupla;
    public List<NameSpriteTupla> m_itemSpriteTupla;

    public Sprite GetEnemySpriteByName(string name)
    {
        for (int i = 0; i < m_enemySpriteTupla.Count; i++)
        {
            if (m_enemySpriteTupla[i].m_name.Equals(name))
            {
                return m_enemySpriteTupla[i].m_sprite;
            }
        }

        return null;
    }   
    
    public Sprite GetTrapSpriteByName(string name)
    {
        for (int i = 0; i < m_trapSpriteTupla.Count; i++)
        {
            if (m_trapSpriteTupla[i].m_name.Equals(name))
            {
                return m_trapSpriteTupla[i].m_sprite;
            }
        }

        return null;
    }  

    public Sprite GetItemSpriteByName(string name)
    {
        for (int i = 0; i < m_itemSpriteTupla.Count; i++)
        {
            if (m_itemSpriteTupla[i].m_name.Equals(name))
            {
                return m_itemSpriteTupla[i].m_sprite;
            }
        }

        return null;
    }  
}
