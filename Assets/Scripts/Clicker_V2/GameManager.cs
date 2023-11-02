using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using static RoomData;

public class GameManager : MonoBehaviour
{
    private LabyrinthData m_labyrinth;

    public static PlayerController m_player;
    private EnemyBehaviour m_enemy;
    private List<RoomData> m_rooms;  // Usaremos una lista para almacenar las habitaciones en orden aleatorio
    private int currentRoomIndex = 0; // Índice de la habitación actual
    private bool m_gameOver = false;
    public RoomsController m_roomController;
    public UIController m_uiController;
    private SpriteSelector m_spriteSelector;

    public Animator anim;
    public string animName;
    public string iconName;

    public GameObject menu;
    public GameObject winScreen;
    public GameObject gameOverScreen;

    public int maxRoomsToGenerate = 10;

    public GameObject btnRestart;
    public GameObject btnStart;

    public TextMeshProUGUI txtDaño;
    public TextMeshProUGUI txtArmadura;



    void Start()
    {
        m_spriteSelector = GetComponent<SpriteSelector>();
        winScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        btnRestart.SetActive(false);
    }

    private void Update()
    {
    }


    public void StartGame()
    {
        menu.SetActive(false);
        winScreen.SetActive(false);
        gameOverScreen.SetActive(false);

        m_player = new PlayerController(10, 5, 50, 50, 20, 0);

        m_uiController.EnableGameUI(true);
        m_uiController.EnableStartButton(false);
        m_uiController.EnableEnemyBar(true);
        m_uiController.EnemyLifeBar(100, 100);
        m_uiController.PlayerLifeBar(m_player.GetCurrentLife(), m_player.GetMaxLife());
        m_gameOver = false;

        // Crear una lista con todas las habitaciones que deseas incluir
        m_rooms = new List<RoomData>
        {
            new RoomData(new EnemyData("Ojo", 10, 5, 10, 60, 5000, 10, 1, 20, "IdleFlying")),
            new RoomData(new EnemyData("Goblin", 15, 5, 1, 60, 10, 10, 1, 20, "IdleGoblin")),
            new RoomData(new EnemyData("SlimeAzul", 20, 2, 17, 0, 10, 10, 2, 20, "SlimeAzul")),
            new RoomData(new EnemyData("SlimeRojo", 10, 2, 50, 60, 25, 30, 3, 10, "SlimeRojo")),

            new RoomData(new ItemData("Pocima", 10, 0, 0, 0, 0, -5)),
            new RoomData(new ItemData("Elixir", 20, 50, 0, 0, 0, -10)),
            //new RoomData(new ItemData("Mana", 0, 15, 0, 0, 0, -5)),
            //new RoomData(new ItemData("Manzana", 5, 0, 0, 0, 0, -3)),
            new RoomData(new ItemData("Queso", 3, 0, 0, 0, 0, -2)),
            //new RoomData(new ItemData("Cerveza", 0, 0, 5, 2, 0, -10)),
            new RoomData(new ItemData("Espada", 0, 0, 10, 0, 0, -5)),
            //new RoomData(new ItemData("Lanza", 0, 0, 12, 0, 0, -8)),
            new RoomData(new ItemData("Maza", 0, 0, 15, 0, 0, -13)),
            //new RoomData(new ItemData("Bara", 0, -3, 6, 0, 0, -5)),
            //new RoomData(new ItemData("Arco", 0, 0, 4, 0, 0, -2)),
            new RoomData(new ItemData("ArcoFuerte", 0, 0, 6, 0, 0, -5)),
            new RoomData(new ItemData("ArmaduraFloja", 0, 0, 0, 5, 0, -5)),
            new RoomData(new ItemData("ArmaduraFuerte", 0, 0, 0, 10, 0, -5)),

            new RoomData(new TrapData("DañoGeneral", -10, -10, 0, 0)),
            //new RoomData(new TrapData("TrampaMana", 0, -17, 0, 0)),
            new RoomData(new TrapData("TrampaDaño", 0, 0, 0, 0)),
            new RoomData(new TrapData("ReduccionArmadura", 0, 0, -2, 0)),
            new RoomData(new TrapData("ReduccionDaño", 0, 0, 0, -3))
            // Agregar más habitaciones aquí si es necesario
        };

        // Aleatorizar el orden de las habitaciones
        ShuffleRooms();

        // Iniciar el laberinto
        ChangeRoom();
        }

    // Método para aleatorizar las habitaciones
    private void ShuffleRooms()
    {
        int n = m_rooms.Count;
        for (int i = 0; i < n; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, n);
            RoomData temp = m_rooms[i];
            m_rooms[i] = m_rooms[randomIndex];
            m_rooms[randomIndex] = temp;
        }

        // Límita la lista m_rooms a un máximo de maxRoomsToGenerate
        if (maxRoomsToGenerate < n)
        {
            m_rooms.RemoveRange(maxRoomsToGenerate, n - maxRoomsToGenerate);
        }
    }

  

    public void PlayerAttack()
    {
        if (currentRoomIndex > 0 && currentRoomIndex <= m_rooms.Count)
        {
            RoomData currentRoom = m_rooms[currentRoomIndex - 1];
            if (currentRoom.m_roomType == RoomData.RoomType.ENEMY && currentRoom.m_enemy != null)
            {
                int damageToApply = m_player.Attack(currentRoom.m_enemy);
                m_roomController.GetEnemyRoom().RecieveDamage(damageToApply);
                m_uiController.EnemyLifeBar(currentRoom.m_enemy.m_currentLife, currentRoom.m_enemy.m_maxLife);
                Debug.Log("Enemy Life " + currentRoom.m_enemy.m_currentLife);
                if (m_roomController.GetEnemyRoom().IsDie())
                {
                    Debug.Log("El enemigo ha sido derrotado");
                    //ChangeRoom();
                    m_roomController.DisableRooms();

                }
            }
        }
    }


    public void PlayerStrongAttack()
    {
        if (currentRoomIndex > 0 && currentRoomIndex <= m_rooms.Count)
        {
            RoomData currentRoom = m_rooms[currentRoomIndex - 1];
            if (currentRoom.m_roomType == RoomData.RoomType.ENEMY && currentRoom.m_enemy != null)
            {
                int damageToApply = m_player.StrongAttack(currentRoom.m_enemy);
                m_roomController.GetEnemyRoom().RecieveDamage(damageToApply);
                m_uiController.EnemyLifeBar(currentRoom.m_enemy.m_currentLife, currentRoom.m_enemy.m_maxLife);
                Debug.Log("Enemy Life " + currentRoom.m_enemy.m_currentLife);
                if (m_roomController.GetEnemyRoom().IsDie())
                {
                    Debug.Log("El enemigo ha sido derrotado");
                    //ChangeRoom();
                    m_roomController.DisableRooms();
                }
            }
        }
    }

    public void WinCondition() {
        Debug.Log("FINISH LABYRINTH");
        m_uiController.EnableGameUI(false);
        m_uiController.EnableStartButton(true);
        winScreen.SetActive(false);
        menu.SetActive(true);
        m_roomController.DisableRooms();
        m_gameOver = true;
        winScreen.SetActive(true);
        btnRestart.SetActive(true);
        btnStart.SetActive(false);
        return;
    }
    public void ChangeRoom()
    {
        if (currentRoomIndex >= m_rooms.Count)
        {
            WinCondition();
            return;
        }

        RoomData currentRoom = m_rooms[currentRoomIndex];

        switch (currentRoom.m_roomType)
        {
            case RoomData.RoomType.ENEMY:
                m_uiController.EnableEnemyBar(true);
                if (currentRoom.m_enemy != null)
                {
                    m_roomController.SetRoom(currentRoom.m_enemy, m_spriteSelector.GetEnemySpriteByName(currentRoom.m_enemy.m_name));
                    animName = currentRoom.m_enemy.m_animName;
                    anim.Play(animName);
                }
                break;
            case RoomData.RoomType.ITEM:
                m_uiController.EnableEnemyBar(false);
                if (currentRoom.m_item != null)
                {
                    m_roomController.SetRoom(currentRoom.m_item, m_spriteSelector.GetItemSpriteByName(currentRoom.m_item.m_name));
                }
                break;
            case RoomData.RoomType.TRAP:
                m_uiController.EnableEnemyBar(false);
                if (currentRoom.m_trap != null)
                {
                    m_roomController.SetRoom(currentRoom.m_trap, m_spriteSelector.GetTrapSpriteByName(currentRoom.m_trap.m_name));
                }
                break;
            default:
                break;
        }

        currentRoomIndex++;


        txtDaño.text = $" Daño: {m_player.GetDamage()}";
        txtArmadura.text = $" Armadura:  {m_player.GetArmor()}";
    }

    public void EnemyAttack(int damage)
    {
        m_player.RecieveDamage(damage);
        m_uiController.PlayerLifeBar(m_player.GetCurrentLife(), m_player.GetMaxLife());

        if (m_player.IsDie())
        {
            m_uiController.EnableGameUI(false);
            m_uiController.EnableStartButton(true);
            Debug.Log("PLAYER IS DIE");
            m_roomController.DisableRooms();
            m_gameOver = true;
            gameOverScreen.SetActive(false);
            menu.SetActive(true);
            gameOverScreen.SetActive(true);
        }
    }
    public void ApplyShopItem(ItemData item)
    {
        m_player.ApplyItem(item);

    }

    public void ApplyItem()
    {
        if (currentRoomIndex > 0 && currentRoomIndex <= m_rooms.Count)
        {
            RoomData currentRoom = m_rooms[currentRoomIndex - 1];
            if (currentRoom.m_roomType == RoomData.RoomType.ITEM && currentRoom.m_item != null)
            {
                m_player.ApplyItem(currentRoom.m_item);
                m_uiController.PlayerLifeBar(m_player.GetCurrentLife(), m_player.GetMaxLife());
                print("Vida actual: " + m_player.GetCurrentLife());
            }
        }
    }

    public void ApplyTrap()
    {
        if (currentRoomIndex > 0 && currentRoomIndex <= m_rooms.Count)
        {
            RoomData currentRoom = m_rooms[currentRoomIndex - 1];
            if (currentRoom.m_roomType == RoomData.RoomType.TRAP && currentRoom.m_trap != null)
            {
                m_player.ApplyTrap(currentRoom.m_trap);
                m_uiController.PlayerLifeBar(m_player.GetCurrentLife(), m_player.GetMaxLife());
                print("Vida actual trampa: " + m_player.GetCurrentLife());

                if (m_player.IsDie())
                {
                    m_uiController.EnableGameUI(false);
                    m_uiController.EnableStartButton(true);
                    Debug.Log("PLAYER IS DIE");
                    m_roomController.DisableRooms();
                    m_gameOver = true;
                    gameOverScreen.SetActive(false);
                    menu.SetActive(true);
                    gameOverScreen.SetActive(true);
                }
            }
        }
    }

    public void RestartGame()
    {
        // Restablece todas las variables y valores del juego a sus valores iniciales
        // Donde Reset es un método que reinicia las estadísticas del jugador
        // Restablece las habitaciones generadas, el estado del juego, etc.

        // Vuelve a cargar la escena actual (asegúrate de guardar la escena actual en la build settings)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      
    }

}
