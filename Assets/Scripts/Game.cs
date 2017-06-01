using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    // PlayerTurn
    public static string player = "Player1";

    // Construction
    public static int boxNumberPlayer;
    public static int boxNumberPlayerLeft;
    public static LayerMask hitLayers;
    public static LayerMask hitLayersPlayer1;
    public static LayerMask hitLayersPlayer2;

    // Destruction
    public static int nbRock;
    public static int nbRockLeft;

    // La boite est tombée
    public static bool boxPlaced = true;

    // Settings Box
    public static float timePerBox = 2f;
    public static Color colorBox = new Color(255, 0, 0);

    // Phase de jeu
    public static bool ConstructionPhase = true;
    public static bool DestructionPhase = false;

    // Score
    public static int scorePlayer1 = 0;
    public static int scorePlayer2 = 0;
    public static int nbPlayerWinner = 1;

    // UI
    public static bool showPlayerIndicator = false;
    public static bool endTurnEnabled = false;

    // CountDown
    public static float timeCountDown = 10.0f;
    public static float timeCountDownLeft = timeCountDown;

    public static void UpdateCameraTo(string cameraPosition)
    {
        //Switch what view the camera has depending on what room we have selected in the DrawRoomGUI
        switch (cameraPosition)
        {
            case "Player1":
                Camera.main.transform.position = new Vector3(0, 15, 0);
                break;

            case "Player2":
                Camera.main.transform.position = new Vector3(0, 15, 65);
                Camera.main.transform.eulerAngles = new Vector3(30, -180, 0);
                break;

            case "Player1Destruction":
                Camera.main.transform.position = new Vector3(0, 5, 19);
                Camera.main.transform.eulerAngles = new Vector3(0, 0, 0);
                break;

            case "Player2Destruction":
                Camera.main.transform.position = new Vector3(0, 5, 47);
                Camera.main.transform.eulerAngles = new Vector3(0, -180, 0);
                break;

        }
    }

    public static void EvaluateWinner()
    {
        if (scorePlayer1 > scorePlayer2)
        {
            nbPlayerWinner = 1;
        }
        else if (scorePlayer1 < scorePlayer2)
        {
            nbPlayerWinner = 2;
        }
        else
        {
            nbPlayerWinner = 0;
        }
    }
}
