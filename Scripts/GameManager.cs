using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Restart() {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoadTutorial() {
        Application.LoadLevel("Tutorial");
    }

    public void LoadGameScene() {
        Application.LoadLevel("Game");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
           Restart(); 
        } 
    }
}
