using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public bool isOnGround = true;
    public bool gameOver = false;
    public float jumpForce;
    public float highGravity;
    public float lowGravity;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Jump when you press the space bar
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            //Alternativ jump
            //playerRb.AddForce(Vector2.up * Time.deltaTime * jumpForce, ForceMode2D.Impulse);
            playerRb.velocity = Vector2.up * jumpForce;
            isOnGround = false;
        }

        // Going down faster than up during a jump
        //if (!Input.GetKey(KeyCode.Space) && isOnGround == false)
        //{
        //    playerRb.velocity = Vector2.down * jumpForce * 2;
        //}

        //Lower gravity when holding the up key in order to make the player glide
        if (Input.GetKey(KeyCode.UpArrow) && isOnGround == false)
        {
            playerRb.gravityScale = lowGravity;
        }
        //Raise the gravity in order to make the player fall faster
        else if (Input.GetKey(KeyCode.DownArrow) && isOnGround == false)
        {
            playerRb.gravityScale = highGravity;
        }
        else
        {
            playerRb.gravityScale = 5;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
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
    }
}
