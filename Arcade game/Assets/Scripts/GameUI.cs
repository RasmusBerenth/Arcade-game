using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextEnd;
    public GameObject gameOverScreen;
    public GameObject scoreObject;

    PlayerControlls playerControllsScripts;

    // Start is called before the first frame update
    void Start()
    {
        playerControllsScripts = GameObject.Find("Player").GetComponent<PlayerControlls>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + playerControllsScripts.score;
        scoreTextEnd.text = "Score: " + playerControllsScripts.score;

        if (playerControllsScripts.gameOver == true)
        {
            gameOverScreen.SetActive(true);
            scoreObject.SetActive(false);
        }
    }
}
