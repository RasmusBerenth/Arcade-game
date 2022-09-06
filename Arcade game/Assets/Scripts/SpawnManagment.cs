using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagment : MonoBehaviour
{
    public GameObject[] environmentChunks;
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
        int randomChunk = Random.Range(0, environmentChunks.Length);
        Vector2 spawnPosition = new Vector2(70, -11);

        Instantiate(environmentChunks[randomChunk], spawnPosition, environmentChunks[randomChunk].transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            Debug.Log("Triggerd");
            SpawnChunks();
        }
    }
}
