using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlayer2 : MonoBehaviour {

    private int currentScore = 0;

    Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore != Game.scorePlayer2)
        { 
            currentScore = Game.scorePlayer2;
            text.text = "Player 2 : " + currentScore;
        }

    }
}
