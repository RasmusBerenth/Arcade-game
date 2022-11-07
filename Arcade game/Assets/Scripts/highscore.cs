using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class highscore : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Awake()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
