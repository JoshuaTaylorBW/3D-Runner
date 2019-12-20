using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterGenerationManager : MonoBehaviour
{
    public int chosenCharacter = 0;

    void Start() {
        chosenCharacter = PlayerPrefs.GetInt("Chosen_Character", 0);
        SpawnCharacter(chosenCharacter);
    }

    public void SpawnCharacter(int characterId)
    {
        switch(characterId) {
            case 0:
                SpawnTheCaptain();
                break;
            case 1:
                SpawnTheDamage();
                break;
            default:
                SpawnTheDamage();
                break; 
        } 
    }

    //Captain ID: 0
    public void SpawnTheCaptain() {
        GameObject characterToSpawn;
        characterToSpawn = Instantiate(Resources.Load("Characters/The_Captain/Player Character"), new Vector3(-272f, -38f, 1108f), Quaternion.identity) as GameObject;
        characterToSpawn.name = "Player Character";
    }

    //Damage ID: 1
    public void SpawnTheDamage() {
        GameObject characterToSpawn;
        characterToSpawn = Instantiate(Resources.Load("Characters/The_Damage/Player Character"), new Vector3(-272f, -38f, 1108f), Quaternion.identity) as GameObject; 
        characterToSpawn.name = "Player Character";
    }

    public void SetChosenCharacter(int characterId) {
        PlayerPrefs.SetInt("Chosen_Character", characterId);
        Application.LoadLevel(Application.loadedLevel);
    }

    void Update()
    {
        
    }
}
