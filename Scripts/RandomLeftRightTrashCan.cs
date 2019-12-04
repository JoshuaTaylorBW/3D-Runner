using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLeftRightTrashCan : MonoBehaviour
{

    private bool onTheLeft;

    void Start()
    {
        onTheLeft = Random.Range(0, 2) == 0 ? true : false;        
        transform.position = new Vector3(onTheLeft ? -90 : 90, transform.position.y, transform.position.z);
    }
}
