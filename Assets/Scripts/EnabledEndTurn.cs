using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnabledEndTurn : MonoBehaviour {
    // Update is called once per frame
    public void Update()
    {
        if ((Game.endTurnEnabled && Game.boxNumberPlayerLeft == 0) || Game.nbRockLeft == 0)
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }
}