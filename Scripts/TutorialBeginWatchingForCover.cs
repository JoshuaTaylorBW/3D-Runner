using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBeginWatchingForCover : MonoBehaviour
{

    public bool hasBegunWatching = false;
    public bool hasTakenCover = false;
    public PlayerCharacter player;

    void Start()
    {
        player = GameObject.Find("Player Character").GetComponent<PlayerCharacter>(); 
    }

    void OnCollisionEnter(Collision col) 
    {
        if(col.gameObject.tag == "Player") {
            hasBegunWatching = true;
        }
    }

    void Update()
    {
        if(hasBegunWatching && !hasTakenCover) {
            if(player.IsCovering()) {
                hasTakenCover = true; 
            }
        }
    }

    public bool PlayerHasTakenCover() {
       return hasTakenCover; 
    } 
}
