using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlayer1 : MonoBehaviour {

    private int currentScore = 0;

    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		if (currentScore != Game.scorePlayer1)
        {
            currentScore = Game.scorePlayer1;
            text.text = "Player 1 : " + currentScore;
        }

    }
}
