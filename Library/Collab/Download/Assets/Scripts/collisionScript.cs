using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionScript : MonoBehaviour {

    // Use this for initialization
    void OnCollisionEnter(Collision col)
    {
        Game.boxPlaced = true;
    }
}
