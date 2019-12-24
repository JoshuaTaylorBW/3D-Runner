using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheCaptain : PlayerCharacter
{

    public bool willGetPrecisionModifier = true;
    public bool hasAddedPrecisionModifier = false;
    public bool hasHitEnemy = false;
    public bool hasShot = false;
    public int precisionModifierWorth = 0; 
    private GameObject missText;
    private GameObject perfectText;

    public override void Shot(bool hit) {
        if(hit) {
            hasHitEnemy = true;
        }

        hasShot = true;

    }

    public override void BeginAiming() {
        aiming = true; 

        movementManager.PauseMovement();

        scoreManager.ResetMultiplier();
        willGetPrecisionModifier = true;
        hasAddedPrecisionModifier = false;
        hasHitEnemy = false;
        precisionModifierWorth = 0;
        scoreManager.SetMultiplier(0);


        anim.SetBool("aiming", true);
        StartCoroutine("Aiming");
    }

    public override IEnumerator Aiming() {
        yield return new WaitForSeconds(AimTime); 

        if(willGetPrecisionModifier && precisionModifierWorth > 1) {
            scoreManager.SetMultiplier(precisionModifierWorth * 2);
            StartCoroutine("ShowAndHidePerfectText");
            hasAddedPrecisionModifier = true;
        }

        if(scoreManager.GetMultiplier() == 0) {
            scoreManager.SetMultiplier(1);
        }

        anim.SetBool("aiming", false);
        movementManager.PlayMovement();
        aiming = false;

    }

    public override void CharacterUpdate() {
        if(Input.GetMouseButtonUp(0) && IsAiming()) {
            if(hasHitEnemy) {
                precisionModifierWorth++;
            }else{
                willGetPrecisionModifier = false;
                StartCoroutine("ShowAndHideMissText");
            }            

           hasHitEnemy = false; 

        } 

        if(missText == null) {
           missText = GameObject.Find("Miss!"); 
           perfectText = GameObject.Find("Perfect!"); 
        }

    }

    IEnumerator ShowAndHideMissText() {
        missText.GetComponent<Text>().text = "Miss!";
        yield return new WaitForSeconds(0.1f);
        missText.GetComponent<Text>().text = "";
    }

    IEnumerator ShowAndHidePerfectText() {
        perfectText.GetComponent<Text>().text = "PERFECT!";
        yield return new WaitForSeconds(1f);
        perfectText.GetComponent<Text>().text = "";
    }

    



}
