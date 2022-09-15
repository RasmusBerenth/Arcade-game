using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagment : MonoBehaviour
{
    public GameObject[] environmentChunks;
    public GameObject[] environmentChunks1;
    public GameObject[] environmentChunks2;
    public GameObject[] environmentBonusChunks;

    public float startDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnChunks", startDelay, spawnInterval);
        Invoke("SpawnChunks", startDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnChunks()
    {
        //Where the chunks will spawn and which one will spawn.
        int randomChunk = Random.Range(0, environmentChunks1.Length);
        Vector2 spawnPosition = new Vector2(70, -12);

        //environmentChunks1 instead of environmentChunks
        Instantiate(environmentChunks1[randomChunk], spawnPosition, environmentChunks1[randomChunk].transform.rotation);
    }

    //potensial
    void SpawnChunks1()
    {
        //Where the chunks will spawn and which one will spawn.
        int randomChunk = Random.Range(0, environmentChunks2.Length);
        Vector2 spawnPosition = new Vector2(70, -12);

        Instantiate(environmentChunks2[randomChunk], spawnPosition, environmentChunks2[randomChunk].transform.rotation);
    }

    void SpawnChunksB()
    {
        //Where the chunks will spawn and which one will spawn.
        int randomChunk = Random.Range(0, environmentBonusChunks.Length);
        Vector2 spawnPosition = new Vector2(70, -12);

        Instantiate(environmentBonusChunks[randomChunk], spawnPosition, environmentBonusChunks[randomChunk].transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Spawn new chunk when hitting the spawner

        if (collision.CompareTag("Respawn"))
        {
            Debug.Log("Triggerd");
            SpawnChunks();
        }

        if (collision.CompareTag("Respawn1"))
        {
            Debug.Log("Triggerd2");
            SpawnChunks1();
        }

        if (collision.CompareTag("RespawnB"))
        {
            Debug.Log("Triggerd B");
            SpawnChunksB();
        }
    }
}
