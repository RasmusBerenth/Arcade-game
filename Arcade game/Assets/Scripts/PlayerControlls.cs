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
    public float jumpGravity = 5;
    public float regularGravity = 10;
    private float score = 0;



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        isOnGroundScript = GameObject.Find("PlayerFeats").GetComponent<IsOnGround>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jump when you press the space bar
        if (Input.GetKey(KeyCode.Space) && isOnGroundScript.isOnGround == true)
        {
            playerRb.velocity = Vector2.up * jumpForce;
            playerRb.gravityScale = jumpGravity;
            isOnGroundScript.isOnGround = false;
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
        else
        {
            playerRb.gravityScale = regularGravity;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    isOnGround = true;
    //}

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
