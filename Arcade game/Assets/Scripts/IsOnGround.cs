using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOnGround : MonoBehaviour
{
    public bool isOnGround;
    PlayerControlls playerControllsScript;
    SpawnManagment spawnManagmentScript;
    OutOfBound outOfBoundScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllsScript = GameObject.Find("Player").GetComponent<PlayerControlls>();
        outOfBoundScript = GameObject.Find("Player").GetComponent<OutOfBound>();
        spawnManagmentScript = GameObject.Find("Spawner").GetComponent<SpawnManagment>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Cheacks when the player is on the ground, sets jumps to 2 and booleans preventing/detering the player from jumping to high (hasSpawned and toHigh booleans)
        isOnGround = true;
        playerControllsScript.jumps = 2;
        spawnManagmentScript.hasSpawned = false;
        outOfBoundScript.toHigh = false;
    }
}
