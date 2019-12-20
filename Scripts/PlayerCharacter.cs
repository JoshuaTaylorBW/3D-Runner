using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class PlayerCharacter : MonoBehaviour
{

    private GameObject camera;
    private MovementManager movementManager; 
    private PlayerHealthManager healthManager;
    private GameManager gameManager;
    private ScoreManager scoreManager;

    [Range(0, 2)] 
    private int lane = 1;
    public int baseMovementSpeed = 0;
    public float inputDelay = 0.5f;
    public float AimTime = 0.5f;
    private bool canInput = true;
    private bool inputBlockedForRolling = false;
    private Animator anim;

    public bool rolling = false;
    public bool aiming = false;
    public bool covering = false;
    public bool dead = false;


    protected virtual void Start()
    {
        movementManager = GameObject.Find("Movement Manager").GetComponent<MovementManager>();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        healthManager = this.gameObject.GetComponent<PlayerHealthManager>();
        camera = GameObject.Find("Main Camera"); 
        anim = transform.GetChild(1).GetComponent<Animator>();
    }

    protected virtual void Update()
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

    public virtual void MoveLeft() {
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

    public virtual void MoveRight() {
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

    public virtual void Roll() {
        if(canInput) {
            anim.SetTrigger("Roll");
        }
    } 

    public virtual void Die() {
        gameManager.UpdateValues();
        movementManager.PauseMovement();
        anim.SetBool("dead", true);
        dead = true;
    }

    public virtual void BeginAiming() {
        aiming = true; 
        movementManager.PauseMovement();
        scoreManager.ResetMultiplier();
        anim.SetBool("aiming", true);
        StartCoroutine("Aiming");
    }

    IEnumerator Aiming() {
        yield return new WaitForSeconds(AimTime); 
        anim.SetBool("aiming", false);
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
        anim.SetBool("taking_cover", cover);
    } 

    public bool IsRolling() {
        return rolling; 
    }

    public int GetLane() {
        return lane; 
    }

    public int GetBaseMovementSpeed() {
        return baseMovementSpeed; 
    }

    public bool IsCovering() {
        return covering; 
    }

    public bool IsDead() {
        return dead; 
    }

    public bool IsAiming() {
        return aiming; 
    }

}

