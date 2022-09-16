using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private IsOnGround isOnGroundScript;

    public bool gameOver = false;
    public float jumpForce;
    public float highGravity;
    public float lowGravity;
    public float jumpGravity;
    public float regularGravity;
    private float score = 0;
    public int jumps = 2;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        isOnGroundScript = GameObject.Find("PlayerFeats").GetComponent<IsOnGround>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jump when you press the space bar (this can happen twice)
        if (Input.GetKeyDown(KeyCode.Space) && isOnGroundScript.isOnGround == true || Input.GetKeyDown(KeyCode.Space) && jumps > 0)
        {
            if (jumps == 1)
            {
                jumpForce = jumpForce - 5;
            }
            else if (jumps == 2)
            {
                jumpForce = 25;
            }

            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            isOnGroundScript.isOnGround = false;
            jumps -= 1;
        }

        //Player goes down faster than they go up in a regular jump
        if (isOnGroundScript.isOnGround == true)
        {
            playerRb.gravityScale = jumpGravity;
        }
        else if (isOnGroundScript.isOnGround == false)
        {
            playerRb.gravityScale = regularGravity;
        }

        //Lower gravity when holding the up key in order to make the player glide
        if (Input.GetKey(KeyCode.UpArrow) && isOnGroundScript.isOnGround == false)
        {
            playerRb.gravityScale = lowGravity;
        }
        //Raise the gravity in order to make the player fall faster
        else if (Input.GetKey(KeyCode.DownArrow) && isOnGroundScript.isOnGround == false)
        {
            playerRb.gravityScale = highGravity;
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

        if (collision.CompareTag("Collectable"))
        {
            score += 1;
            Debug.Log($"Score: {score}");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Bonus"))
        {
            score *= 2;
            Debug.Log($"Score: {score}");
            Destroy(collision.gameObject);
        }
    }
}
