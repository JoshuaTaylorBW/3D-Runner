using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckForHitOnEnemy : MonoBehaviour
{

    public PlayerWeapon playerWeapon;
    public PlayerCharacter playerCharacter;
    public ScoreManager scoreManager;
    public bool overMarker;

    public bool isDead = false;

    public bool hasShot = false;

    public GameObject missText;


    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        playerWeapon = GameObject.Find("Player Character").GetComponent<PlayerWeapon>(); 
        playerCharacter = GameObject.Find("Player Character").GetComponent<PlayerCharacter>(); 
        missText = GameObject.Find("Miss!"); 
    }

    void OnMouseOver()
    {
        overMarker = true;

        if(playerWeapon.IsSwipeToKill()) {
            playerCharacter.Shot(true);
            KillEnemy();
        }
    }

    void OnMouseExit()
    {
        if(!isDead) {
            overMarker = false;
        }
    }

    public void KillEnemy()
    {
        isDead = true;
        GameObject.Destroy(this.transform.root.gameObject);
        scoreManager.AddToMultiplier(1);
    }

    void Update() {
        if(playerWeapon.IsTapToKill()) { 
            if(Input.GetMouseButtonDown(0) && playerCharacter.IsAiming() && !hasShot) {
                hasShot = true;

                if(overMarker) {
                    playerCharacter.Shot(true);
                    KillEnemy();
                }else{
                    playerCharacter.Shot(false);
                }
            }
        }

        if(Input.GetMouseButtonUp(0)) {
            hasShot = false;
        }
    }

    IEnumerator ShowAndHideMissText() {
        missText.GetComponent<Text>().text = "Miss!";
        yield return new WaitForSeconds(0.1f);
        missText.GetComponent<Text>().text = "";
    }
}
