using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    PlayerControlls playerControllsScript;
    private float speed = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerControllsScript = GameObject.Find("Player").GetComponent<PlayerControlls>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllsScript.gameOver == false)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
    }
}
