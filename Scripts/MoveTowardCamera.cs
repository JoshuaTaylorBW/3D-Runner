using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardCamera : MonoBehaviour
{
    private MovementManager movementManager;
    public float movementSpeed; 

    private Vector3 directionToMove;

    void Start()
    {
        movementManager = GameObject.Find("Movement Manager").GetComponent<MovementManager>();
        movementSpeed = movementManager.GetMovementSpeed();
        directionToMove  = new Vector3(0, 0, -movementSpeed);
    }

    void Update()
    {
        if(movementManager.IsMoving()) {
            transform.position += directionToMove * Time.deltaTime;    
        }
    }

    public void SetMovementSpeed(float newMovementSpeed) {
        movementSpeed = newMovementSpeed;
        directionToMove = new Vector3(0, 0, -movementSpeed);
    }

}
