using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeactivateOnTrigger : MonoBehaviour
{

    public GameObject speedUpText;

    void Start() {
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
            speedUpText = GameObject.Find("Speed Up"); 
            speedUpText.SetActive(false);
        }
    }
}
