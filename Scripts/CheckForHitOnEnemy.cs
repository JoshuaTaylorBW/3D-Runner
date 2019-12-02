using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForHitOnEnemy : MonoBehaviour
{

    public PlayerCharacter player;
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        player = GameObject.Find("Player Character").GetComponent<PlayerCharacter>(); 
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && player.IsAiming())
        {
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        GameObject.Destroy(this.transform.root.gameObject);
        scoreManager.AddToMultiplier();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
