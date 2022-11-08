using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class highscore : MonoBehaviour
{
    //Displays the highscore in the main menu
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Awake()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }


    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScoreText.text = "High Score: 0";

    }
}
