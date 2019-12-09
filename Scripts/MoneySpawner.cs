using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    public List<string> moneyLayouts;

    void Start()
    {
        if(moneyLayouts.Count > 0) SpawnMoney();    
    }

    void SpawnMoney() {
        GameObject layoutToBuild;
        int layoutToSpawn = Random.Range(0, moneyLayouts.Count);

        layoutToBuild = Instantiate(Resources.Load("Money_Patterns/" + moneyLayouts[layoutToSpawn]), Vector3.zero, Quaternion.identity) as GameObject; 
        layoutToBuild.transform.parent = this.gameObject.transform; 
        layoutToBuild.transform.localPosition = Vector3.zero;
    }
}
