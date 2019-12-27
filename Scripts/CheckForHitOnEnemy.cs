using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckForHitOnEnemy : MonoBehaviour
{

    public PlayerWeapon playerWeapon;
    public PlayerCharacter playerCharacter;
    public ScoreManager scoreManager;

    public GameObject missText;

    public GameObject enemy;

    public Animator hitMarkerAnimator;

    public bool overMarker;
    public bool isDead = false;
    public bool hasShot = false;

    void Start()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        playerWeapon = GameObject.Find("Player Character").GetComponent<PlayerWeapon>(); 
        enemy = transform.root.gameObject; 
        hitMarkerAnimator = GetComponent<Animator>(); 
        playerCharacter = GameObject.Find("Player Character").GetComponent<PlayerCharacter>(); 
        missText = GameObject.Find("Miss!"); 
    }

    void OnMouseOver()
    {
        overMarker = true;

        if(playerWeapon.IsSwipeToKill()) {
            hitMarkerAnimator.SetTrigger("Swiped");
            enemy.GetComponent<Enemy>().Swiped();
            playerCharacter.KilledEnemy(enemy);
            GetComponent<BoxCollider>().enabled = false;
            playerCharacter.Shot(true);
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
