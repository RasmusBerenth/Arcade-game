using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextEnd;
    public TextMeshProUGUI highScoreText;

    public GameObject gameOverScreen;
    public GameObject scoreObject;

    private PlayerControlls playerControllsScripts;

    // Start is called before the first frame update
    void Start()
    {
        playerControllsScripts = GameObject.Find("Player").GetComponent<PlayerControlls>();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    public void Update()
    {
        //Replace highscore
        if (playerControllsScripts.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", playerControllsScripts.score);
            highScoreText.text = "New High Score: " + playerControllsScripts.score.ToString();
        }

        //Display Score in UI
        scoreText.text = "Score: " + playerControllsScripts.score;
        scoreTextEnd.text = "Score: " + playerControllsScripts.score;

        if (playerControllsScripts.gameOver == true)
        {
            StartCoroutine(WaitForEnd());
        }
    }

    //Short pause while deathparticles plays until the "game over screen" apears
    IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(playerControllsScripts.deathParticles.main.duration - 1f);

        gameOverScreen.SetActive(true);
        scoreObject.SetActive(false);
    }
}
