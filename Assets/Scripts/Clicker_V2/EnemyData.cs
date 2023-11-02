using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    public string m_name;
    public int m_damage;
    public int m_defense;
    public int m_maxLife;
    public int m_maxMana;
    public int m_rewardExperience;
    public int m_rewardGold;
    public float m_timeBetweenAttacks;
    public int m_percentageStrongAttack;

    public string m_animName;

    public int m_currentLife;
    private int m_currentMana;



    public EnemyData(string name, int damage, int defense, int maxLife, int maxMana, int rewardExperience, int rewardGold, int timeBetweenAttacks, int percentageStrongAttack, string animName)
    {
        m_name = name;
        m_damage = damage;
        m_defense = defense;
        m_maxLife = maxLife;
        m_maxMana = maxMana;
        m_rewardExperience = rewardExperience;
        m_rewardGold = rewardGold;
        m_timeBetweenAttacks = timeBetweenAttacks;
        m_percentageStrongAttack = Mathf.Clamp(percentageStrongAttack, 0, 100);

        m_currentLife = maxLife;
        m_currentMana = maxMana;

        m_animName = animName;



    }
}
