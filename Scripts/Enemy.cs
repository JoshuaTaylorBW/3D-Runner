using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    private bool alert;
    private bool isPositioning;
    private bool isAiming;
    private bool isSearching;

    [Header("Movement")]
    public float movementSpeed;
    public float maxMovementTime;
    private Random movementRandom; 
    private float movementDistance;
    private bool moveRight;
    private PlayerCharacter player;
    public float timeBeforeSecondPeriod;
    public float timeBeforeYellowPeriod;
    public float timeBeforeAlert;
    public float timeEnemyIsAlert;

    private Animator EnemyHudAnimator;
    private Animator EnemyAnimator;
    private GameObject hitMarker;

    // Start is called before the first frame update
    void Start()
    {
        movementRandom = new Random(); 
        hitMarker = transform.GetChild(1).gameObject;
        BeginPositioning();

        isSearching = true;

        movementSpeed = moveRight ? movementSpeed : -movementSpeed;
        player = GameObject.Find("Player Character").GetComponent<PlayerCharacter>();
        EnemyHudAnimator = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>(); 

        EnemyAnimator = GetComponent<Animator>();

    }

    void BeginPositioning() {
        isPositioning = true;
        hitMarker.transform.position = new Vector3(0.14f, 0.27f, hitMarker.transform.position.z);
        StartCoroutine("RunUntilAim");
    }

    IEnumerator RunUntilAim() {
        float movementTime = Random.Range(2.0f, maxMovementTime);
        yield return new WaitForSeconds(movementTime);
        isPositioning = false;
        EnemyAnimator.SetTrigger("Aiming");
        hitMarker.transform.position = new Vector3(0.055f, 0.365f, hitMarker.transform.position.z);
        isAiming = true;
        StartCoroutine("WaitUntilSecondPeriod");
    }

    IEnumerator WaitUntilSecondPeriod() {
        yield return new WaitForSeconds(timeBeforeSecondPeriod);
        EnemyHudAnimator.SetTrigger("Second Period");
        StartCoroutine("WaitUntilYellowPeriod");
    }

    IEnumerator WaitUntilYellowPeriod() {
        yield return new WaitForSeconds(timeBeforeSecondPeriod);
        EnemyHudAnimator.SetTrigger("Third Period");
        StartCoroutine("WaitUntilAlert");
    }

    IEnumerator WaitUntilAlert() {
        yield return new WaitForSeconds(timeBeforeSecondPeriod);
        EnemyHudAnimator.SetTrigger("Third Period"); 
        if(isSearching) {
            StartCoroutine("IsAlert");
        }
    }

    IEnumerator IsAlert() {
        yield return new WaitForSeconds(timeBeforeAlert);
        EnemyHudAnimator.SetTrigger("Alert"); 
        alert = true;
        StartCoroutine("WaitUntilOnePeriod");
    }

    IEnumerator WaitUntilOnePeriod() {
        yield return new WaitForSeconds(timeEnemyIsAlert);
        EnemyHudAnimator.SetTrigger("First Period"); 
        alert = false;
        StartCoroutine("WaitUntilSecondPeriod");
    } 

    void Update()
    {
        if(isPositioning) {
            transform.position += new Vector3(movementSpeed, 0, 0) * Time.deltaTime;
        }

        if(alert) {
            if(!player.IsCovering()) {
                player.GetHit();
                StopCoroutine("WaitUntilOnePeriod");
                EnemyHudAnimator.SetTrigger("First Period"); 
                alert = false;
                StartCoroutine("WaitUntilSecondPeriod");
            }
        }

        if(player.IsAiming()) 
        {
            hitMarker.SetActive(true); //show hit marker when player is aiming
        }else{
            hitMarker.SetActive(false); //show hit marker when player is aiming
        }

    }

    public void Swiped() {
        player.Shot(true);
        isSearching = false;
    }

     

    public void SetMoveRight(bool right) {
        moveRight = right;
    }

}

