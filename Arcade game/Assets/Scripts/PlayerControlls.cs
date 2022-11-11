using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControlls : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private IsOnGround isOnGroundScript;
    private MoveLeft moveLeftScript;

    public Animator animations;

    public ParticleSystem lostSoulParticles;
    public ParticleSystem goodSoulParticles;
    public ParticleSystem playerSpeedParticles;
    public ParticleSystem bonusSpeedParticles;
    public ParticleSystem deathParticles;

    public AudioClip lostSoulSound;
    public AudioClip goodSoulSound;
    private AudioSource playerSound;

    public bool gameOver = false;
    private bool hasPowerUp = false;
    private bool Collected = false;

    public bool canGlide = false;
    public bool canDive = false;

    [SerializeField] private float jumpForce;
    [SerializeField] private float highGravity;
    [SerializeField] private float lowGravity;
    [SerializeField] private float jumpGravity;
    [SerializeField] private float regularGravity;
    [SerializeField] private float removedJumpForce = 5;

    public int score = 0;
    public int jumps = 2;

    private int scorePoint;
    private int soulsCollected;

    private GameControlls controlls;

    private void Awake()
    {
        controlls = new GameControlls();

        controlls.GamePlayControlls.Jump.performed += context => OnJump();
        controlls.GamePlayControlls.Glide.performed += context => OnGlide(context);
        controlls.GamePlayControlls.Dive.performed += context => OnDive(context);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerSound = GetComponent<AudioSource>();

        playerRb = GetComponent<Rigidbody2D>();

        isOnGroundScript = GameObject.Find("PlayerFeats").GetComponent<IsOnGround>();
        moveLeftScript = GameObject.Find("ground").GetComponent<MoveLeft>();

        animations = GameObject.Find("ghost sprite").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate the speed lines based on the players volocity
        playerSpeedParticles.transform.LookAt(playerRb.position - playerRb.velocity - moveLeftScript.speed * Vector2.right);
        bonusSpeedParticles.transform.LookAt(playerRb.position - playerRb.velocity - moveLeftScript.speed * Vector2.right);

        //Switch to and from power up mode
        if (hasPowerUp == true)
        {
            scorePoint = 2;
        }
        else
        {
            scorePoint = 1;
        }

        //Player goes down faster than they go up in a regular jump and regulating animation booleans
        if (isOnGroundScript.isOnGround == true)
        {
            playerRb.gravityScale = jumpGravity;

            animations.SetBool("grounded_bool", true);
        }
        else if (isOnGroundScript.isOnGround == false)
        {
            playerRb.gravityScale = regularGravity;

            animations.SetBool("grounded_bool", false);

            animations.SetBool("dive_bool", false);
            animations.SetBool("glide_bool", false);
        }

        //Lower gravity when holding the up key in order to make the player glide
        if (canGlide == true && isOnGroundScript.isOnGround == false)
        {
            playerRb.gravityScale = lowGravity;
            animations.SetBool("glide_bool", true);
        }
        //Raise the gravity in order to make the player fall faster
        else if (canDive == true && isOnGroundScript.isOnGround == false)
        {
            playerRb.gravityScale = highGravity;
            animations.SetBool("dive_bool", true);
        }
        else
        {
            animations.SetBool("dive_bool", false);
            animations.SetBool("glide_bool", false);
        }

        Collected = false;
    }

    void OnJump()
    {
        //Jump when you press the space bar (this can happen twice)
        if (isOnGroundScript.isOnGround == true || jumps > 0)
        {
            //Second jump
            if (jumps == 1)
            {
                jumpForce = jumpForce - removedJumpForce;
            }
            //First jump (slightly weaker than the second jump)
            else if (jumps == 2)
            {
                jumpForce = 25;
            }

            animations.SetTrigger("jump_trig");

            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            isOnGroundScript.isOnGround = false;

            jumps -= 1;
        }
    }

    void OnGlide(InputAction.CallbackContext context)
    {
        canGlide = context.ReadValueAsButton();
    }

    void OnDive(InputAction.CallbackContext context)
    {
        canDive = context.ReadValueAsButton();
    }


    private void OnEnable()
    {
        controlls.GamePlayControlls.Enable();
    }

    private void OnDisable()
    {
        controlls.GamePlayControlls.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //If player collides with an "enemy" the game is over
        if (collision.CompareTag("Enemy"))
        {
            gameOver = true;

            var main = deathParticles.main;
            main.maxParticles = soulsCollected;
            deathParticles.transform.parent = null;
            deathParticles.Play();

            playerSpeedParticles.Stop();
            bonusSpeedParticles.Stop();

            Destroy(gameObject);
        }
        //Collectables are worth 1 point
        if (collision.CompareTag("Collectable"))
        {
            if (!Collected)
            {
                Collected = true;

                score += scorePoint;
                Destroy(collision.gameObject);

                lostSoulParticles.Play();

                playerSound.PlayOneShot(lostSoulSound, 0.7f);

                soulsCollected++;
            }
        }
        //Bonus collectables dubble your score gained from lost souls for a short duration
        if (collision.CompareTag("Bonus"))
        {
            Destroy(collision.gameObject);
            hasPowerUp = true;

            StartCoroutine(GoodSoulTimer());

            playerSpeedParticles.Stop();
            goodSoulParticles.Play();
            bonusSpeedParticles.Play();

            playerSound.PlayOneShot(goodSoulSound, 0.6f);
        }
    }


    //How long the power up mode last (10 seconds) and also stops and plays the appropiate trails
    IEnumerator GoodSoulTimer()
    {
        yield return new WaitForSeconds(10);
        hasPowerUp = false;
        bonusSpeedParticles.Stop();
        playerSpeedParticles.Play();
    }
}
