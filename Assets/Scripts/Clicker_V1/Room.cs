using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public enum RoomType { ENEMY, ITEM, TRAP };

    public RoomType m_roomType;
    public Trap m_trap;
    public Enemy m_enemy;
    public Item m_item;

    public Room(Trap trap)
    {
        m_roomType = RoomType.TRAP;
        m_trap = trap;
    }

    public Room(Enemy enemy)
    {
        m_roomType = RoomType.ENEMY;
        m_enemy = enemy;
    }

    public Room(Item item)
    {
        m_roomType = RoomType.ITEM;
        m_item = item;
    }

    public void EnterRoom()
    {
        switch (m_roomType)
        {
            case RoomType.ENEMY:
                m_enemy.Greet();
                break;
            case RoomType.ITEM:
                m_item.DrawItem();
                break;
            case RoomType.TRAP:
                m_trap.ActionTrap();
                break;
            default:
                break;
        }
    }
}
