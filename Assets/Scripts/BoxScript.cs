using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour {


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Terrain.activeTerrain.gameObject)
        {
            Destroy(this.gameObject);

            // Attribution des points de score
            //if (!Game.ConstructionPhase)
            //{
            if (this.tag == "Player1")
            {
                Game.scorePlayer2 += 1;
            }
            else
            {
                Game.scorePlayer1 += 1;
            }
            //}
        }
    }
}
