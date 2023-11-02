using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private int m_damage;
    private int m_defense;
    private int m_maxLife;
    private int m_maxMana;

    [SerializeField] private int m_currentLife;
    private int m_currentMana;
    private int m_currentExp;
    private int m_maxExp;


    public PlayerController(int damage, int defense, int maxLife, int maxMana, int experienceToNextLevel, int currentExp)
    {
        m_damage = damage;
        m_defense = defense;
        m_maxLife = maxLife;
        m_maxMana = maxMana;

        m_currentLife = maxLife;
        m_currentMana = maxMana;

        m_currentExp = currentExp;
    }

    public void RecieveDamage(int damage)
    {
        int currentDamage = damage - m_defense;

        if (currentDamage > 0)
        {
            m_currentLife -= damage - m_defense;
            Debug.Log("Ay!");
        }
    }

    public int Attack(EnemyData enemy)
    {

        int damageAux = m_damage;

        return damageAux;
    }

    public int StrongAttack(EnemyData enemy)
    {
        int damageAux = m_damage * 2;

        return damageAux;
    }

    public int GetMaxLife()
    {
        return m_maxLife;
    }

    public int GetCurrentLife()
    {
        return m_currentLife;
    }

    public int GetCurrentExp()
    {
        return m_currentExp;
    }

    public int GetDamage()
    {
        return m_damage;
    }

    public int GetArmor()
    {
        return m_defense;
    }

    public void ApplyItem(ItemData item)
    {
        m_currentLife += item.m_lifeUp;
        m_currentMana += item.m_manaUp;
        m_damage += item.m_damageUp;
        m_defense += item.m_defenseUp;

    }

    public void ApplyTrap(TrapData trap)
    {
        m_currentLife += trap.m_playerDamage;
        m_currentMana += trap.m_manaDamage;
        m_damage += trap.m_attackReduction;
        m_defense += trap.m_armorReduction;
    }

    public bool IsDie()
    {
        if (m_currentLife <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
