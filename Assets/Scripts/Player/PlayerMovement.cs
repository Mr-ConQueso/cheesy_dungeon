using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //---/ Public | Inspector Variables /---//
    [SerializeField] private float setMovementCooldown = 0.2F;
    [SerializeField] private float playerSpeed = 2.0F;
    [SerializeField] private float squareSize = 0.32F;
    [SerializeField] private float checkRadius = 0.02F;
    [SerializeField] private Transform playerMoveTowards;
    [SerializeField] private LayerMask stopsMovement;

    //---/ Private Variables /---//
    private float movementCooldown = 0;

    void Start() {
        
        playerMoveTowards.parent = null;
    }

    void Update() {

        movementCooldown -= Time.deltaTime;

        if (movementCooldown <= 0)
        {
            movementCooldown = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, playerMoveTowards.position, playerSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, playerMoveTowards.position) <= 0.05f && movementCooldown == 0) {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {

                if (!Physics2D.OverlapCircle(playerMoveTowards.position + new Vector3(Input.GetAxisRaw("Horizontal") * squareSize, 0f, 0f), checkRadius, stopsMovement)) {
                    
                    playerMoveTowards.position += new Vector3(Input.GetAxisRaw("Horizontal") * squareSize, 0f, 0f);
                    movementCooldown = setMovementCooldown;
                }
            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {

                if (!Physics2D.OverlapCircle(playerMoveTowards.position + new Vector3(0f, Input.GetAxisRaw("Vertical") * squareSize, 0f), checkRadius, stopsMovement)) {
                    
                    playerMoveTowards.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * squareSize, 0f);
                    movementCooldown = setMovementCooldown;
                }
            }
        }
    }
}