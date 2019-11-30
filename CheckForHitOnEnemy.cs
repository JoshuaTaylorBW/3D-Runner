using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForHitOnEnemy : MonoBehaviour
{

    public PlayerCharacter player;

    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.Find("Player Character").GetComponent<PlayerCharacter>(); 
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && player.IsAiming())
        {
            Debug.Log("Clicked");
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        GameObject.Destroy(this.transform.root.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
