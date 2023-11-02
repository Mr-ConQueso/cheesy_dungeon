using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrapInputBehaviour : MonoBehaviour
{
    public GameManager m_gameManager;

    float m_counterRoomTime;
    float m_timeToChangeRoom;

    private void Start()
    {
        m_counterRoomTime  = 0;
        m_timeToChangeRoom = 1;
    }

    void Update()
    {
        m_counterRoomTime += Time.time;

        if (Input.GetMouseButtonDown(0) && m_counterRoomTime >= m_timeToChangeRoom)
        {
            m_gameManager.ApplyTrap();
            m_gameManager.m_roomController.DisableRooms();
        }
    }
}
