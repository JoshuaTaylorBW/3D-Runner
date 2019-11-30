using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForCover : MonoBehaviour
{
    private MovementManager movementManager; 
    private PlayerHealthManager healthManager; 
    private PlayerCharacter playerCharacter; 
    private Animator Anim;
    public float invincibilityTime = 1f;
    public bool invincible;

    // Start is called before the first frame update
    void Start()
    {
        movementManager = GameObject.Find("Movement Manager").GetComponent<MovementManager>();
        playerCharacter = transform.root.gameObject.GetComponent<PlayerCharacter>();
        healthManager = transform.root.gameObject.GetComponent<PlayerHealthManager>();
        Anim = transform.root.GetChild(1).gameObject.GetComponent<Animator>();
    }


    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Cover") {
            Anim.SetBool("taking_cover", true);
            movementManager.PauseMovement();
            playerCharacter.setCover(true);
        }

        if(col.gameObject.tag == "Roll Obstacle") {
            if(!playerCharacter.IsRolling() && !invincible) {
                healthManager.getHit();
                invincible = true;
                StartCoroutine("StartInvincibilityTimer");
            }
        }

        if(col.gameObject.tag == "Obstacle") {
            if(!invincible) {
                healthManager.getHit();
                invincible = true;
                StartCoroutine("StartInvincibilityTimer");
            }
        }

    }

    void OnCollisionExit(Collision col) {
        if(col.gameObject.tag == "Cover") {
            playerCharacter.BeginAiming();
            Anim.SetBool("taking_cover", false);
            playerCharacter.setCover(false);
        }
    }

    IEnumerator StartInvincibilityTimer() {
        yield return new WaitForSeconds(invincibilityTime);
        invincible = false;
    }

}
