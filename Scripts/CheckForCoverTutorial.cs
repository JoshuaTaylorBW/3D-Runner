using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForCoverTutorial : MonoBehaviour
{

    public PlayerCharacter player;
    private MovementManager movementManager; 
    public GameObject tutorialTextToShow; 

    void Start()
    {
        player = GameObject.Find("Player Character").GetComponent<PlayerCharacter>(); 
        movementManager = GameObject.Find("Movement Manager").GetComponent<MovementManager>();
    }

    void Update()
    {
        if(player.IsCovering()) {
            GameObject.Destroy(this.gameObject);
            tutorialTextToShow.SetActive(true);
        }         
    }
}
