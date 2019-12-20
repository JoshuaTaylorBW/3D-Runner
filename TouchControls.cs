using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class TouchControls : MonoBehaviour
{

    public GameObject player;

    void Start()
    {
        LeanTouch.OnFingerSwipe += HandleFingerSwipe; 

        player = null;
    }

    public void HandleFingerSwipe(LeanFinger finger) {

        Vector2 screenFrom = finger.StartScreenPosition;
        Vector2 screenTo = finger.ScreenPosition;

        var finalDelta = screenTo - screenFrom;
        var angle = Mathf.Atan2(finalDelta.x, finalDelta.y) * Mathf.Rad2Deg;

        if(DidSwipeAtRequiredAngle(angle, 90)) {
            player.GetComponent<PlayerCharacter>().MoveRight();
        }

        //SWIPED LEFT
        if(DidSwipeAtRequiredAngle(angle, 270)) {
            player.GetComponent<PlayerCharacter>().MoveLeft();
        }

        //SWIPED DOWN
        if(DidSwipeAtRequiredAngle(angle, 180)) {
            player.GetComponent<PlayerCharacter>().Roll();
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

        if(player.GetComponent<PlayerCharacter>().IsDead()) {
           LeanTouch.OnFingerSwipe -= HandleFingerSwipe; 
        }
    }
}