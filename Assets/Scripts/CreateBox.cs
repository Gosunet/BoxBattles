using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBox : MonoBehaviour
{

    public GameObject prefab;
    public LayerMask hitLayersPlayer1;
    public LayerMask hitLayersPlayer2;
    public float yOffstet;
    public float timeToCreateNewBox;
    public int boxNumber;

    private bool placed;
    private float timeLeft;
    private bool updateOn;
    private GameObject moveThis;

    // Use this for initialization
    void Start()
    {
        // Hit Layer
        Game.hitLayers = hitLayersPlayer1;
        Game.hitLayersPlayer1 = hitLayersPlayer1;
        Game.hitLayersPlayer2 = hitLayersPlayer2;

        updateOn = true;
        // objectFalling = false;
        placed = false;
        timeLeft = timeToCreateNewBox;
        Game.boxNumberPlayer = boxNumber;
        Game.boxNumberPlayerLeft = boxNumber;
        // First Box
        this.NewBox();
    }

    // Update is called once per frame
    void Update()
    {
        if (Game.ConstructionPhase)
        {
            // Drop the Box
            if (Input.GetMouseButtonDown(0) && Game.boxNumberPlayerLeft >= 0)
            {
                if (moveThis)
                {
                    moveThis.GetComponent<Rigidbody>().isKinematic = false;
                    placed = true;
                    Game.endTurnEnabled = true;
                }
            }
            //else if (cameraToChange && Game.boxPlaced)
            //{
            //    Game.timePerBox -= Time.deltaTime;
            //    if (Game.timePerBox < 0 && Game.boxPlaced)
            //    {
            //        Game.showPlayerIndicator = false;
            //        hitLayers = hitLayersPlayer2;
            //        Game.UpdateCameraTo("Player2");
            //        cameraToChange = false;

            //    }
            //}


            if (!placed)
            {
                Game.endTurnEnabled = false;
                Vector3 mouse = Input.mousePosition;
                Ray castPoint = Camera.main.ScreenPointToRay(mouse);
                RaycastHit hit;
                if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, Game.hitLayers))
                {
                    moveThis.GetComponent<Rigidbody>().isKinematic = true;
                    moveThis.transform.position = hit.point + new Vector3(0, yOffstet, 0);
                }
            }
            else if (updateOn)
            {
                // Create a new Box after a small time if all the box havn't been placed.
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0 && Game.boxNumberPlayerLeft > 0)
                {
                    this.NewBox();
                }
                //if (Game.boxNumberPlayerLeft == 0)
                //{
                //    Si le joueur 2 a placé ses boites, on stop l'update
                //    if (Game.currentTag == "Player2")
                //    {
                //        updateOn = false;
                //        // Mise à jour de la camera
                //        Game.ConstructionPhase = false;
                //    }
                //    Game.currentTag = "Player2";
                //    Game.colorBox = new Color(0, 255, 0);
                //    boxNumber = Game.boxNumberPlayer;

                //    if (Game.boxPlaced)
                //    {
                //        cameraToChange = true;
                //    }
                //}
            }
        }
    }
    void NewBox()
    {
        // Instanciate a new Box
        Vector3 mouse = Input.mousePosition;
        moveThis = Instantiate(prefab, new Vector3(mouse.x, 30, mouse.z), Quaternion.identity) as GameObject;
        // Tag
        moveThis.tag = Game.player;
        moveThis.GetComponentInChildren<Light>().color = Game.colorBox;
        Game.boxNumberPlayerLeft--;
        // Reset value
        timeLeft = timeToCreateNewBox;
        placed = false;
        moveThis.GetComponent<Rigidbody>().isKinematic = true;
    }
}
