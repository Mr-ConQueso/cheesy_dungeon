using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyInputBehaviour : MonoBehaviour
{
    public GameManager m_gameManager;

    float m_counterButtonTime = 0;

    private void Start()
    {
        m_counterButtonTime = Time.time;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_counterButtonTime = Time.time;
        }

        if ( Input.GetMouseButtonUp (0) && (Time.time - m_counterButtonTime < 0.25f))
        {
            m_gameManager.PlayerAttack();
        }

        if ( Input.GetMouseButtonUp (0) && (Time.time - m_counterButtonTime > 0.25f))
        {
            m_gameManager.PlayerStrongAttack();
        }
    }
}
