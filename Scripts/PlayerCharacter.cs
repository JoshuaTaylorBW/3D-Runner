using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    private GameObject camera;
    private MovementManager movementManager; 
    private PlayerHealthManager healthManager;
    private GameManager gameManager;
    private ScoreManager scoreManager;

    [Range(0, 2)] 
    private int lane = 1;
    public float inputDelay = 0.5f;
    public float AimTime = 0.5f;
    private bool canInput = true;
    private bool inputBlockedForRolling = false;
    private Animator Anim;

    public bool rolling = false;
    public bool aiming = false;
    public bool covering = false;
    public bool dead = false;


    void Start()
    {
        movementManager = GameObject.Find("Movement Manager").GetComponent<MovementManager>();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        healthManager = this.gameObject.GetComponent<PlayerHealthManager>();
        camera = GameObject.Find("Main Camera"); 
        Anim = transform.GetChild(1).GetComponent<Animator>();
    }

    void Update()
    {

        if(PlayerInputsLeft() && canInput) {
            MoveLeft();
        } else if(PlayerInputsRight() && canInput) {
            MoveRight();
        }else if(PlayerInputsDown()) {
            Roll();
        }

        if(rolling) {
            canInput = false;
            inputBlockedForRolling = true;
        }

        if(inputBlockedForRolling){
            if(!rolling){
                canInput = true;
                inputBlockedForRolling = false;
            }
        }

    }

    public void MoveLeft() {
        if(lane > 0) {
            transform.position = new Vector3(
                transform.position.x - 85.5f,
                transform.position.y,
                transform.position.z
            );        

            camera.transform.position = new Vector3(
                camera.transform.position.x - 85.5f,
                camera.transform.position.y,
                camera.transform.position.z
            );    

            lane -= 1;

            StartCoroutine("InputDelay");
        }
    }

    public void MoveRight() {
       if(lane < 2) {
            transform.position = new Vector3(
                transform.position.x + 85.5f,
                transform.position.y,
                transform.position.z
            );        

            camera.transform.position = new Vector3(
                camera.transform.position.x + 85.5f,
                camera.transform.position.y,
                camera.transform.position.z
            );    

            lane += 1;
            StartCoroutine("InputDelay");
        } 
    }

    public void Roll() {
        if(canInput) {
            Anim.SetTrigger("Roll");
        }
    } 

    public void Die() {
        gameManager.UpdateValues();
        dead = true;
    }

    public void BeginAiming() {
        aiming = true; 
        movementManager.PauseMovement();
        scoreManager.ResetMultiplier();
        StartCoroutine("Aiming");
    }

    IEnumerator Aiming() {
        yield return new WaitForSeconds(AimTime); 
        movementManager.PlayMovement();
        aiming = false;

    }

    bool PlayerInputsLeft() {
        return (Input.GetKeyDown(KeyCode.A));
    }

    bool PlayerInputsRight() {
        return (Input.GetKeyDown(KeyCode.D));
    }

    bool PlayerInputsDown() {
        return (Input.GetKeyDown(KeyCode.S));
    }

    IEnumerator InputDelay() {
        canInput = false;
        yield return new WaitForSeconds(inputDelay);
        canInput = true;
    }

    public void GetHit() {
        healthManager.getHit();
    }

    public void setRolling(bool roll) {
        rolling = roll;
    }

    public void setCover(bool cover) {
        covering = cover;  
    } 

    public bool IsRolling() {
        return rolling; 
    }

    public int GetLane() {
        return lane; 
    }

    public bool IsCovering() {
        return covering; 
    }

    public bool IsAiming() {
        return aiming; 
    }

}

