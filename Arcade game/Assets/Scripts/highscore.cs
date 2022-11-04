using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class highscore : MonoBehaviour
{
    GameUI gameUIScript;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Awaken()
    {
        gameUIScript = GetComponent<GameUI>();
        highScoreText.text = gameUIScript.highScoreText.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
