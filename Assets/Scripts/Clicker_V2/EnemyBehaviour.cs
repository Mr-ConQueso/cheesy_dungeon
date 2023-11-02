using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyBehaviour : MonoBehaviour
{
    public  GameManager    m_gameManager;
    public  EnemyData      m_enemyData;
    public  SpriteRenderer m_sprite;
    private float          m_counterTime;

    /**Exp**/
    public int experienciaGanada;
    public SistemaExperiencia sistemaExperiencia;

    public int nivel = 1;
    public int experienciaActual = 0;
    public int experienciaSiguienteNivel = 100; // Experiencia necesaria para el próximo nivel
    public int vidaBase = 100;
    public int defensaBase = 10;
    public int danioBase = 5;
    public int VidaMaxima = 9999;
    public int DefensaMaxima = 9999;
    public int DanioMaximo = 9999;

    public TextMeshProUGUI playerExp;


    public int oro;
    public int plata;
    public int gemas;

    public int cantidadOroObtenida;
    public int cantidadPlataObtenida;
    public int cantidadGemasObtenidas;



    public void Start()
    {
        m_counterTime = 0;

        oro = 0;
        plata = 0;
        gemas = 0;

        cantidadOroObtenida = 0;
        cantidadPlataObtenida = 0;
        cantidadGemasObtenidas = 0;
    }


    public void SetEnemy (EnemyData enemyData)
    {
        m_enemyData = enemyData;
    }

    public void Greet         ()
    {
        Debug.Log("Un enemigo ha aparecido! Es un " + m_enemyData.m_name + "!");
        Debug.Log("Tiene una fuerza de " + m_enemyData.m_damage);
        Debug.Log("Tiene una vida de " + m_enemyData.m_currentLife);
    }

    public void Attack        ()
    {
        int attackValue = Random.Range(0, 100);
        int damage      = 0;

        if (attackValue <= m_enemyData.m_percentageStrongAttack)
        {
            damage = m_enemyData.m_damage;
            Debug.Log(m_enemyData.m_name + " hace un ataque flojo");
        }
        else
        {
            damage = m_enemyData.m_damage * 2;
            Debug.Log(m_enemyData.m_name + " hace un ataque fuerte");
        }

        m_gameManager.EnemyAttack(damage);
    }

    public void RecieveDamage (int damage)
    {
        int currentDamage = damage - m_enemyData.m_defense;

        if (currentDamage > 0)
        {
            Debug.Log("Ouch!");
            m_enemyData.m_currentLife -= damage - m_enemyData.m_defense;
        }

        if (m_enemyData.m_currentLife < 0)
        {
            // PLAYER DIE
            Debug.Log("Not tod...argfrfgfgr");
        }
    }

    public bool IsDie         ()
    {
        if (m_enemyData.m_currentLife <= 0)
        {
            AumentarExperiencia(experienciaGanada);
            print("nivel: " + nivel + "exp: " + experienciaActual);
            Economia();
            return true;
            
        }
        else
        {
            return false;
        }
    }

    public void Update   ()
    {
        m_counterTime += Time.deltaTime;

        if (m_counterTime > m_enemyData.m_timeBetweenAttacks)
        {
            m_counterTime = 0;
            Attack ();
        }

        playerExp.text = $" {nivel}" + $"/ {experienciaActual}/{experienciaSiguienteNivel}";



    }

    public void AumentarExperiencia(int experienciaGanada)
    {

        experienciaGanada = m_enemyData.m_rewardExperience;
        experienciaActual += experienciaGanada;
        while (experienciaActual >= experienciaSiguienteNivel && nivel < 99)
        {
            SubirNivel();
        }

    }

    public void SubirNivel()
    {
        nivel++;
        experienciaSiguienteNivel = CalcularExperienciaSiguienteNivel();
        vidaBase = Mathf.FloorToInt(Mathf.Min(vidaBase * 1.2f, VidaMaxima));
        defensaBase = Mathf.FloorToInt(Mathf.Min(defensaBase * 1.15f, DefensaMaxima));
        danioBase = Mathf.FloorToInt(Mathf.Min(danioBase * 1.2f, DanioMaximo));
        

    }

    public int CalcularExperienciaSiguienteNivel()
    {
        // Fórmula para calcular la experiencia necesaria para el próximo nivel
        return Mathf.FloorToInt(Mathf.Pow(nivel + 1, 3) * 100);
    }

    public void Economia()
    {
        int randomNum = Random.Range(1, 101);
        cantidadOroObtenida = 0;
        cantidadPlataObtenida = 0;
        cantidadGemasObtenidas = 0;

        if (randomNum <= 40)
        {
            cantidadOroObtenida = Random.Range(1, 16);
            oro += cantidadOroObtenida;
        }
        else if (randomNum <= 90)
        {
            cantidadPlataObtenida = Random.Range(1, 50);
            plata += cantidadPlataObtenida;
        }
        else
        {
            cantidadGemasObtenidas = Random.Range(1, 2);
            gemas += cantidadGemasObtenidas;
        }

        if (plata >= 100)
        {
            int conversionOro = plata / 100;
            oro += conversionOro;
            plata %= 100;
        }
        if (oro >= 100)
        {
            int conversionGemas = oro / 100;
            gemas += conversionGemas;
            oro %= 100;
        }
    }

}
