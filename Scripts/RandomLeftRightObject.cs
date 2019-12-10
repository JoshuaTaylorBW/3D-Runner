using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLeftRightObject : MonoBehaviour
{

    private bool onTheLeft;
    public bool shouldSwitchOtherObjectPlacement;
    public GameObject objectToSwitch;
    [Header("Object to switch properties")]
    public bool switchToOppositeSide;

    void Start()
    {
        onTheLeft = Random.Range(0, 2) == 0 ? true : false;        

        transform.position = new Vector3(onTheLeft ? -90 : 90, transform.position.y, transform.position.z);

        if(shouldSwitchOtherObjectPlacement) {
            if(switchToOppositeSide) {
                objectToSwitch.transform.position = new Vector3(onTheLeft ? 90 : -90, objectToSwitch.transform.position.y, objectToSwitch.transform.position.z);
            }else{
                objectToSwitch.transform.position = new Vector3(onTheLeft ? -90 : 90, objectToSwitch.transform.position.y, objectToSwitch.transform.position.z);
            }
        }
    }
}
