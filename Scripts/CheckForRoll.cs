using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForRoll : MonoBehaviour
{

    public PlayerCharacter player;
    private MovementManager movementManager; 

    void Start()
    {
        player = GameObject.Find("Player Character").GetComponent<PlayerCharacter>(); 
        movementManager = GameObject.Find("Movement Manager").GetComponent<MovementManager>();
    }

    void Update()
    {
        if(player.IsRolling()) {
            movementManager.PlayMovement();
            GameObject.Destroy(this.gameObject);
        }         
    }
}
