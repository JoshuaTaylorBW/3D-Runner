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

    public List<GameObject> swipedEnemies;

    public override void CharacterStart() {
        swipedEnemies = new List<GameObject>();
    }

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
        swipedEnemies.Clear();


        anim.SetBool("aiming", true);
        StartCoroutine("Aiming");
    }

    public override IEnumerator Aiming() {

        yield return new WaitForSeconds(AimTime); 

        for(int i = 0; i < swipedEnemies.Count; i++) {
            Debug.Log("From for");
            scoreManager.AddToMultiplier(1);
            GameObject.Destroy(swipedEnemies[i]);
        }

        if(scoreManager.GetMultiplier() > 1) {
            scoreManager.SetMultiplier(scoreManager.GetMultiplier());
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

    public override void KilledEnemy(GameObject enemy) {
        swipedEnemies.Add(enemy);
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
