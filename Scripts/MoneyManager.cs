using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int totalCoins = 0;
    public Text coinText;

    void Start()
    {
       coinText = GameObject.Find("Money Text").GetComponent<Text>();
    }

    public void AddCoinsToTotal(int amountToAdd) {
        totalCoins += amountToAdd;
        coinText.text = totalCoins.ToString();
    }

    void Update()
    {
        
    }
}
