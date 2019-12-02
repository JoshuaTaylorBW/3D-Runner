using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollCheck : MonoBehaviour
{

    public bool rolling;
    public PlayerCharacter player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player Character").GetComponent<PlayerCharacter>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(rolling) {
            player.setRolling(true);
        }else{
            player.setRolling(false);
        } 
    }
}
