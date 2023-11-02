using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthData 
{
    List<RoomData>  m_labyrinth;
    int             m_currentIndexRoom;
    
    public      LabyrinthData       ()
    {
        m_labyrinth        = new List<RoomData>();
        m_currentIndexRoom = -1;
    }

    public void AddRoom         (RoomData room)
    {
        m_labyrinth.Add(room);
    }

    public void ChangeRoom      ()
    {
        m_currentIndexRoom++;

        Debug.Log("Entrando en una nueva sala...");

        
    }

    public RoomData GetCurrentRoom  ()
    {
        if (m_currentIndexRoom < m_labyrinth.Count && m_labyrinth[m_currentIndexRoom] != null)
        {
            return m_labyrinth[m_currentIndexRoom];
        }

        return null;
    }

    public bool IsFinished         ()
    {
        if (m_labyrinth.Count <= m_currentIndexRoom)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
