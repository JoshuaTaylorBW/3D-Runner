using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardCamera : MonoBehaviour
{
    private MovementManager movementManager;
    private float movementSpeed; 

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
}
