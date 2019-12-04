using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpTrigger : MonoBehaviour
{

    public LevelUpManager lum;
    public Text speedUpText;

    void Start()
    {
        lum = GameObject.Find("Level Up Manager").GetComponent<LevelUpManager>(); 
    }


    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
            lum.LevelUp();
        }
    }
}
