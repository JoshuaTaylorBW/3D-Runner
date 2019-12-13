using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{

    public MoneyManager moneyManager;

    // Start is called before the first frame update
    void Start()
    {
        moneyManager = GameObject.Find("Money Manager").GetComponent<MoneyManager>();
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Player") {
            moneyManager.AddCoinsToTotal(1);
            GameObject.Destroy(this.gameObject);
        }
    }
}
