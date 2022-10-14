using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private IsOnGround isOnGroundScript;

    public Animator animations;

    public bool gameOver = false;
    public float jumpForce;
    public float highGravity;
    public float lowGravity;
    public float jumpGravity;
    public float regularGravity;
    private float score = 0;
    public int jumps = 2;

    private int scorePoint = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        isOnGroundScript = GameObject.Find("PlayerFeats").GetComponent<IsOnGround>();
        animations = GameObject.Find("ghost sprite").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jump when you press the space bar (this can happen twice)
        if (Input.GetKeyDown(KeyCode.Space) && isOnGroundScript.isOnGround == true || Input.GetKeyDown(KeyCode.Space) && jumps > 0)
        {
            //First jump (slightly weaker than the second jump)
            if (jumps == 1)
            {
                jumpForce = jumpForce - 5;
            }
            //Second jump
            else if (jumps == 2)
            {
                jumpForce = 25;
            }

            animations.SetTrigger("jump_trig");

            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            isOnGroundScript.isOnGround = false;

            jumps -= 1;
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

        }

        //Lower gravity when holding the up key in order to make the player glide
        if (Input.GetKey(KeyCode.UpArrow) && isOnGroundScript.isOnGround == false)
        {
            playerRb.gravityScale = lowGravity;
            animations.SetBool("glide_bool", true);
        }
        //Raise the gravity in order to make the player fall faster
        else if (Input.GetKey(KeyCode.DownArrow) && isOnGroundScript.isOnGround == false)
        {
            playerRb.gravityScale = highGravity;
            animations.SetBool("dive_bool", true);
        }
        else
        {
            animations.SetBool("dive_bool", false);
            animations.SetBool("glide_bool", false);
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If player collides with an "enemy" the game is over
        if (collision.CompareTag("Enemy"))
        {
            gameOver = true;
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
        //Collectables are worth 1 point
        if (collision.CompareTag("Collectable"))
        {
            score += scorePoint;
            Debug.Log($"Score: {score}");
            Destroy(collision.gameObject);
        }
        //Bonus collectables dubble your score
        if (collision.CompareTag("Bonus"))
        {
            score *= 2;
            Debug.Log($"Score: {score}");
            Destroy(collision.gameObject);
        }
    }
}
