using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    public EndTurn endturn;

    Text text;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = Game.timeCountDownLeft.ToString("F0");

        if (Game.DestructionPhase)
        {
            Game.timeCountDownLeft -= Time.deltaTime;
            
            if (Game.timeCountDownLeft < 0)
            {
                Game.timeCountDownLeft = Game.timeCountDown;
                endturn.ChangeTurn();
            }

        }
	}
}
