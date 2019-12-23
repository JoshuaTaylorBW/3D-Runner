using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPortraitContainer : MonoBehaviour
{

    public float distanceToMove = 400f;
    public int chosenCharacter;
    public int amountOfCharacters;    

    void Start()
    {

        distanceToMove = this.gameObject.transform.GetChild(1).GetChild(0).GetComponent<RectTransform>().position.x;

        chosenCharacter = PlayerPrefs.GetInt("Chosen_Character");
        Debug.Log(chosenCharacter);
        transform.position = new Vector3(transform.position.x - ((distanceToMove * chosenCharacter)), transform.position.y, transform.position.z);
        amountOfCharacters = transform.childCount;
    }

    public void MoveRight() {
        if(chosenCharacter > 0) {
            transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
            chosenCharacter--;
            PlayerPrefs.SetInt("Chosen_Character", chosenCharacter);
        }
    }

    public void MoveLeft() {
        if(chosenCharacter < amountOfCharacters - 1) {
            transform.position = new Vector3(transform.position.x - distanceToMove, transform.position.y, transform.position.z);
            chosenCharacter++;
            PlayerPrefs.SetInt("Chosen_Character", chosenCharacter);
        }
    }
}
