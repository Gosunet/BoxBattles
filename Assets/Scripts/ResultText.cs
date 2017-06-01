using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultText : MonoBehaviour {

    Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }
    void Update () {
        if (Game.nbPlayerWinner != 0)
        {
            text.text = "Player " + Game.nbPlayerWinner + " win !";
        }
        else
        {
            text.text = "Draw";
        }
	}
}
