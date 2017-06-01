using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementBox : MonoBehaviour {

    public LayerMask hitLayers;
    public float yOffstet;
    private bool placed;

    // Use this for initialization
    void Start () {
        placed = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            placed = true;
  
        if (!placed)
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, hitLayers))
            {
                this.transform.position = hit.point + new Vector3(0,yOffstet,0);
            }
        }
    }
}
