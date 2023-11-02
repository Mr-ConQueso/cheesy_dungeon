using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform rooms;
    [SerializeField] private Transform camera;
    [SerializeField] private Transform cameraGoTo;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private Transform playerMoveTowards;
    [SerializeField] private GameManager gameManager;

    private float doorCooldown = 0;

    void Start()
    {
        cameraGoTo.parent = null;
    }

    void Update()
    {
        if (Vector3.Distance(camera.position, cameraGoTo.position) >= 0.05f) {

            camera.position = Vector3.MoveTowards(camera.position, cameraGoTo.position, cameraSpeed * Time.deltaTime);
        }

        doorCooldown -= Time.deltaTime;

        if (doorCooldown <= 0)
        {
            doorCooldown = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (doorCooldown == 0) {

            if (collider.tag == "TopDoor") {
                cameraGoTo.position = new Vector3(cameraGoTo.position.x, cameraGoTo.position.y + 2.744981f, -10);
                playerMoveTowards.position += new Vector3(0f, 0.32F * 2, 0f);

                rooms.position += new Vector3(0, 2.744981f, 0);

                doorCooldown = 0.1f;
                gameManager.ChangeRoom();
            }
            else if (collider.tag == "BottomDoor") {
                cameraGoTo.position = new Vector3(cameraGoTo.position.x, cameraGoTo.position.y - 2.744981f, -10);
                playerMoveTowards.position += new Vector3(0f, 0.32F * -2, 0f);

                rooms.position += new Vector3(0, -2.744981f, 0);

                doorCooldown = 0.1f;
                gameManager.ChangeRoom();
            }
            else if (collider.tag == "RightDoor") {
                cameraGoTo.position = new Vector3(cameraGoTo.position.x + 2.744981f, cameraGoTo.position.y, -10);
                playerMoveTowards.position += new Vector3(0.32F * 1.5f, 0f, 0f);

                rooms.position += new Vector3(2.744981f, 0, 0);

                doorCooldown = 0.1f;
                gameManager.ChangeRoom();
            }
            else if (collider.tag == "LeftDoor") {
                cameraGoTo.position = new Vector3(cameraGoTo.position.x - 2.744981f, cameraGoTo.position.y, -10);
                playerMoveTowards.position += new Vector3(0.32F * -1.5f, 0f, 0f);

                rooms.position += new Vector3(-2.744981f, 0, 0);

                doorCooldown = 0.1f;
                gameManager.ChangeRoom();
            }
        }
    }

    void OnTriggerStay2D(Collider2D collider) {

        if (collider.tag == "FinalRoom") {
            gameManager.WinCondition();
        }
    }
}
