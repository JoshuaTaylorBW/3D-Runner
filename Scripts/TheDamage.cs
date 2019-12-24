using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheDamage : PlayerCharacter 
{
    public bool hasAddedPrecisionModifier = false;
    public bool hasHitEnemy = false;
    public int precisionModifierWorth = 0; 
    private GameObject perfectText;

    public override void Shot(bool hit) {
        if(hit) {
            precisionModifierWorth++; 
        }
    }

    public override void BeginAiming() {
        aiming = true; 

        movementManager.PauseMovement();

        scoreManager.ResetMultiplier();
        hasAddedPrecisionModifier = false;
        hasHitEnemy = false;
        precisionModifierWorth = 0;
        scoreManager.SetMultiplier(0);


        anim.SetBool("aiming", true);
        StartCoroutine("Aiming");
    }

    public override IEnumerator Aiming() {
        yield return new WaitForSeconds(AimTime); 


        if(scoreManager.GetMultiplier() > 1) {
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
        if(perfectText == null) {
           perfectText = GameObject.Find("Perfect!"); 
        } 
    }


    IEnumerator ShowAndHidePerfectText() {
        perfectText.GetComponent<Text>().text = "PERFECT!";
        yield return new WaitForSeconds(1f);
        perfectText.GetComponent<Text>().text = "";
    } 

}
