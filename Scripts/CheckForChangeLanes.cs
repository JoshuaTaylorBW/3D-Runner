using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForChangeLanes : MonoBehaviour
{

    public PlayerCharacter player;
    public int playerStartingLane;
    private MovementManager movementManager; 


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player Character").GetComponent<PlayerCharacter>(); 
        movementManager = GameObject.Find("Movement Manager").GetComponent<MovementManager>();
        playerStartingLane = player.GetLane(); 
    }

    void Update()
    {
        if(player.GetLane() != playerStartingLane) {
            movementManager.PlayMovement();
            GameObject.Destroy(this.gameObject);
        }
    }
}
