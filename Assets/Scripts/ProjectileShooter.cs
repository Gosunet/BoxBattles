using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {

    public AudioClip shootSound;
    public GameObject prefab;
    public int speed;
    public int nbRockPlayer;
    public float timeShoot;

    private AudioSource source;
    private float timeLeft;
    private float nbRockLeft;
    private bool projectileShooted;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    // Use this for initialization
    void Start () {
        timeLeft = timeShoot;
        projectileShooted = false;

        // nbRock
        Game.nbRock = nbRockPlayer;
        Game.nbRockLeft = nbRockPlayer;
    }
    void Awake()
    {

        source = GetComponent<AudioSource>();

    }


    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0) && Game.DestructionPhase && !projectileShooted && Game.nbRockLeft > 0)
        {
            var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            position = Camera.main.ScreenToWorldPoint(position);
            var go = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
            go.transform.LookAt(position);
            go.GetComponent<Rigidbody>().AddForce(go.transform.forward * speed);

            // Sound
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(shootSound, vol);

            projectileShooted = true;
            timeLeft = timeShoot;
        }
        if (projectileShooted)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Game.nbRockLeft--;
                //if (nbRockLeft == 0)
                //{
                //    if (Game.player == "Player1")
                //    {
                //        // Go to player2 config
                //        Game.UpdateCameraTo("Player2Destruction");
                //        nbRockLeft = nbRockPlayer;
                //        Game.player = "Player2";
                //    }
                //    else
                //    {
                //        Debug.Log("Game Finished");
                //    }
                //}
                projectileShooted = false;
            }
        }
	}
}
