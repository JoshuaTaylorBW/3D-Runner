using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class TouchControls : MonoBehaviour
{

    public GameObject player;
    public PlayerCharacter playerCharacter;

    public CharacterPortraitContainer characterPortraitContainer; //the gameobject that holds all of the cards containing heroes. We use this to move it.
    public bool notAdded = false;

    void Start()
    {
        LeanTouch.OnFingerSwipe += HandleFingerSwipe; 
        characterPortraitContainer = GameObject.Find("Character Portrait Container").GetComponent<CharacterPortraitContainer>();
    }

    public void HandleFingerSwipe(LeanFinger finger) {
        if(!playerCharacter.IsDead()) {
            HandleGameInput(finger);  
        }else{
            HandleGameOverInput(finger);  
        }

        if(playerCharacter.IsDead()) {
            HandleGameOverInput(finger);  
        }
    } 

    void HandleGameInput(LeanFinger finger) {
        Vector2 screenFrom = finger.StartScreenPosition;
        Vector2 screenTo = finger.ScreenPosition;

        var finalDelta = screenTo - screenFrom;
        var angle = Mathf.Atan2(finalDelta.x, finalDelta.y) * Mathf.Rad2Deg;

        if(DidSwipeAtRequiredAngle(angle, 90)) {
            playerCharacter.MoveRight();
        }

        //SWIPED LEFT
        if(DidSwipeAtRequiredAngle(angle, 270)) {
            playerCharacter.MoveLeft();
        }

        //SWIPED DOWN
        if(DidSwipeAtRequiredAngle(angle, 180)) {
            playerCharacter.Roll();
        } 
    }

    void HandleGameOverInput(LeanFinger finger) {
        Vector2 screenFrom = finger.StartScreenPosition;
        Vector2 screenTo = finger.ScreenPosition;

        var finalDelta = screenTo - screenFrom;
        var angle = Mathf.Atan2(finalDelta.x, finalDelta.y) * Mathf.Rad2Deg;

        if(DidSwipeAtRequiredAngle(angle, 90)) {
            characterPortraitContainer.MoveRight();
        }

        if(DidSwipeAtRequiredAngle(angle, 270)) {
            characterPortraitContainer.MoveLeft();
        }
    }

    bool DidSwipeAtRequiredAngle(float angle, float requiredAngle) {
        var angleDelta = Mathf.DeltaAngle(angle, requiredAngle);

        if (angleDelta < 90 * -0.5f || angleDelta >= 90 * 0.5f)
        {
            return false;
        }

        return true;
    }

    void Update()
    {
        if(player == null) {
            player = GameObject.Find("Player Character");
        }
        if(playerCharacter == null) {
            playerCharacter = player.GetComponent<PlayerCharacter>();
        }        
    }

    public void StopWatchingForTouch() {
        LeanTouch.OnFingerSwipe -= HandleFingerSwipe; 
    } 
}