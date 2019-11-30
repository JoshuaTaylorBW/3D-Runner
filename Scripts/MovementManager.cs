using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{

    public bool moving = true;
    public float movementSpeed;

    public float GetMovementSpeed() {
        return movementSpeed;
    }

    public bool IsMoving() {
        return moving;
    }

    public void PlayMovement() {
        moving = true;
    }

    public void PauseMovement() {
        moving = false;
    }
}
