using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int m_damage;
    private int m_defense;
    private int m_maxLife;
    private int m_maxMana;
    private int m_experienceToNextLevel;


    private int m_currentLife;
    private int m_currentMana;
    private int m_currentExperience;
    private int m_currentLevel = 0;

    private Weapon m_currentWeapon;
    private Shield m_currentShield;

    private int strongAttackModifier = 2;
    private int[] strongAttackModifierValues = { 10, 20, 35, 50 };

    public Player(int damage, int defense, int maxLife, int maxMana, int experienceToNextLevel, Weapon currentWeapon, Shield currentShield)
    {
        m_damage = damage;
        m_defense = defense;
        m_maxLife = maxLife;
        m_maxMana = maxMana;
        m_experienceToNextLevel = experienceToNextLevel;

        m_currentLife = maxLife;
        m_currentMana = maxMana;
        m_currentExperience = 1;

        m_currentWeapon = currentWeapon;
        m_currentShield = currentShield;
    }

    public void AddExperience(int experience)
    {
        m_currentExperience += experience;
        if (m_experienceToNextLevel == m_currentExperience)
        {
            UpLevel();
        }
    }

    public void ReceiveDamage(int damage)
    {
        int totalDefense = (int)(m_defense + m_currentShield.m_resistance);
        int damageTaken = damage - totalDefense;
        if (damageTaken <= 0)
        {
            damageTaken = 1;
        }
        m_currentLife -= damageTaken;
    }

    public void Attack(Enemy enemy)
    {
        int damage = (m_damage + m_currentWeapon.m_damage) - enemy.m_defense;
        if (damage < 0)
        {
            damage = 1;
        }
        enemy.RecieveDamage(damage);
    }

    public void StrongAttack(Enemy enemy)
    {
        int damage = (m_damage + m_currentWeapon.m_damage) * strongAttackModifier - enemy.m_defense;
        if (damage < 0)
        {
            damage = 1;
        }
        enemy.RecieveDamage(damage);
    }

    public void SetWeapon(Weapon weapon)
    {
        m_currentWeapon = weapon;
    }

    public void SetShield(Shield shield)
    {
        m_currentShield = shield;
    }

    public void ApplyItem(Item item)
    {
        if(item.m_weapon == null && item.m_shield == null)
        {
            m_currentLife += item.m_lifeUp;
            //TODO: Diseñar sistema de vida. ¿En que transformo el exceso? ¿Metodo addHealth?

            m_currentMana += item.m_manaUp;
            //TODO: DIseñar sistema de mana. ¿Que hago con el exceso? ¿Metodo addMana?

            m_damage += item.m_damageUp;
            m_defense += item.m_defenseUp;
            AddExperience(item.m_expUp);

            //TODO: Diseñar sistema de economia. ¿Nueva habitacion tipo tienda?, ¿tienda de armas?
        }
        //TODO: Añadir posibilidad item.arma o item.shield con un else if. Hay que crear constructor el clase item y aqui usar el setWeapon / setShield. Cambiar tambien el MainComponent con los valores de item adecuados. 
    }

    public void ApplyTrap(Trap trap)
    {
        //TODO: ¿puede hacer algo mas la trampa. Ej: quitar daño?
        m_currentLife += trap.m_playerDamage;
        m_currentMana += trap.m_manaDamage;
    }

    public void UpLevel()
    {
        m_damage += 10;
        m_defense += 5;
        m_maxLife += 50;
        m_maxMana += 50;

        m_experienceToNextLevel += 20 * m_currentLevel;
        //TODO: tratar de hacerlo exponencial haciendo m_experienceToNextLevel * algo. Tratar que no sean muy altos los valores. Bucar un posible calculo de nivel en internet y explicarlo en caso de usarla.

        m_currentLife = m_maxLife;
        m_currentMana = m_maxMana;

    }

    public bool IsDead()
    {
        if (m_currentLife > 0) return false;

        m_currentLife = 0;
        return true;
    }
}
