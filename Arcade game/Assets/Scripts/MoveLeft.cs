using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    PlayerControlls playerControllsScript;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Controlls the speed of different objects
        playerControllsScript = GameObject.Find("Player").GetComponent<PlayerControlls>();

        if (CompareTag("Enemy")) //The flying enemy moving across the screen when the player jumps to high
        {
            speed = 60;
        }
        //Creating the parallax effect to the background
        else if (CompareTag("Background"))
        {
            speed = 5;
        }
        else if (CompareTag("Background1"))
        {
            speed = 7;
        }
        else if (CompareTag("Background2"))
        {
            speed = 9;
        }
        else
        {
            //Sets difficulty curved
            if (playerControllsScript.score < 30)
            {
                speed = 15;
            }
            else if (playerControllsScript.score < 70)
            {
                speed = 18;
            }
            else
            {
                speed = 20;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move game objects to the left until the game is over
        if (playerControllsScript.gameOver == false)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
    }
}
