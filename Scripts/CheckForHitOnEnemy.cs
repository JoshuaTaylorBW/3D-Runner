using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForHitOnEnemy : MonoBehaviour
{

    public PlayerWeapon playerWeapon;
    public PlayerCharacter playerCharacter;
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        playerWeapon = GameObject.Find("Player Character").GetComponent<PlayerWeapon>(); 
        playerCharacter = GameObject.Find("Player Character").GetComponent<PlayerCharacter>(); 
    }

    void OnMouseOver()
    {
        if(playerWeapon.IsSwipeToKill()) {
            KillEnemy();
        }else if(playerWeapon.IsTapToKill()) {
            if(Input.GetMouseButtonDown(0) && playerCharacter.IsAiming()) {
                KillEnemy();
            }
        }
    }

    public void KillEnemy()
    {
        GameObject.Destroy(this.transform.root.gameObject);
        scoreManager.AddToMultiplier();
    }
}
