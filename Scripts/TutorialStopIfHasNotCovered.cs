using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStopIfHasNotCovered : MonoBehaviour
{

    private MovementManager movementManager; 
    private TutorialBeginWatchingForCover watchForCoverService;

    void Start()
    {
        movementManager = GameObject.Find("Movement Manager").GetComponent<MovementManager>();
        watchForCoverService = GameObject.Find("Begin Watching For Cover").GetComponent<TutorialBeginWatchingForCover>();          
    }

    void OnCollisionEnter(Collision col) 
    {
        if(col.gameObject.tag == "Player") {
            if(!watchForCoverService.PlayerHasTakenCover()) {
                movementManager.PauseMovement();
            }else{
                movementManager.PlayMovement();
            }
        }
    }   

    void Update()
    {
        
    }
}
