using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public Player m_player;
    public string m_name;
    public int m_damage;
    public int m_defense;
    public int m_maxLife;
    public int m_maxMana;
    public int m_rewardExperience;
    public int m_rewardGold;
    public float m_timeBetweenAttacks;
    public int m_percentageStrongAttack;
    public int m_strongAttackModifier = 2;
    

    public int m_currentLife;
    private int m_currentMana;
    private float m_counterTime;


    public Enemy(Player player, string name, int damage, int defense, int maxLife, int maxMana, int rewardExperience, int rewardGold, int timeBetweenAttacks, int percentageStrongAttack)
    {
        m_player = player;
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
    }

    public void Greet()
    {
        Debug.Log("Un enemigo ha aparecido! Es un " + m_name + "!");
        Debug.Log("Tiene una fuerza de " + m_damage + " unidades de energía");
        Debug.Log("Tiene " + m_currentLife + " corazoncicos");
    }

    public void Attack()
    {
        bool isAttackStrong = Random.Range(0, 100) < m_percentageStrongAttack;
        int damage = (isAttackStrong) ? m_damage * m_strongAttackModifier : m_damage;
        m_player.ReceiveDamage(damage);
    }

    public void RecieveDamage(int damage)
    {
        int damageTaken = damage - m_defense;
        if(damageTaken <= 0)
        {
            damage = 1;
        }
        m_currentLife -= damageTaken;
    }

    public bool IsDead()
    {
        return m_currentLife <= 0;
    }

    public void UpdateEnemy(float timeDelta)
    {
        m_counterTime += timeDelta;

        if (m_counterTime > m_timeBetweenAttacks)
        {
            m_counterTime = 0;
            Attack();
        }
    }
}
