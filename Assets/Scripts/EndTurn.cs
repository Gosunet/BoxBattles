using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndTurn : MonoBehaviour
{
    public void ChangeTurn()
    {
        if (Game.ConstructionPhase)
        {
            if (Game.player == "Player1")
            {
                Game.player = "Player2";
                Game.UpdateCameraTo("Player2");
                Game.hitLayers = Game.hitLayersPlayer2;
                Game.colorBox = new Color(0, 255, 0);
                Game.boxNumberPlayerLeft = Game.boxNumberPlayer;
            }
            else
            {
                Game.player = "Player1";
                Game.ConstructionPhase = false;
                Game.DestructionPhase = true;
                Game.endTurnEnabled = false;
                Game.boxNumberPlayerLeft = Game.boxNumberPlayer;
                Game.UpdateCameraTo("Player1Destruction");
            }
        }
        else if (Game.DestructionPhase)
        {
            if (Game.player == "Player1")
            {
                Game.player = "Player2";
                Game.UpdateCameraTo("Player2Destruction");
                Game.nbRockLeft = Game.nbRock;
                Game.timeCountDownLeft = Game.timeCountDown;
            }
            else
            {
                Game.EvaluateWinner();
                SceneManager.LoadScene("Result");
                Game.player = "Player1";
                Game.ConstructionPhase = true;
                Game.DestructionPhase = false;
                Game.boxNumberPlayerLeft = Game.boxNumberPlayer;
                Game.colorBox = new Color(256, 0, 0);
                Game.scorePlayer1 = 0;
                Game.scorePlayer2 = 0;
                Game.timeCountDownLeft = Game.timeCountDown;
            }

        }
    }
}
