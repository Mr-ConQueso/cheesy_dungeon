using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labyrinth
{
    private List<Room> m_labyrinth;
    private Player m_player;
    private int m_currentIndexRoom;

    public Labyrinth(Player player)
    {
        m_player = player;
        m_labyrinth = new List<Room>();
        m_currentIndexRoom = -1;
    }

    public void AddRoom(Room room)
    {
        m_labyrinth.Add(room);
    }

    public void ChangeRoom()
    {
        m_currentIndexRoom++;

        Debug.Log("Entrando en una nueva sala...");

        if (m_labyrinth.Count > m_currentIndexRoom)
        {
            Debug.Log("Elijo la puerta numero dos!");

            m_labyrinth[m_currentIndexRoom].EnterRoom();
            switch (GetCurrentRoom().m_roomType)
            {
                case Room.RoomType.ITEM:
                    m_player.ApplyItem(GetCurrentRoom().m_item);
                    ChangeRoom();
                    break;
                case Room.RoomType.TRAP:
                    m_player.ApplyTrap(GetCurrentRoom().m_trap);
                    ChangeRoom();
                    break;
                default:
                    break;
            }
        }
    }

    public Room GetCurrentRoom()
    {
        if (m_currentIndexRoom < m_labyrinth.Count && m_labyrinth[m_currentIndexRoom] != null)
        {
            return m_labyrinth[m_currentIndexRoom];
        }

        return null;
    }

    public bool IsFinished()
    {
        return m_labyrinth.Count <= m_currentIndexRoom;
    }

    public void UpdateLabyrinth(float time)
    {
        if (GetCurrentRoom().m_roomType == Room.RoomType.ENEMY)
            GetCurrentRoom().m_enemy.UpdateEnemy(time);
    }
}
