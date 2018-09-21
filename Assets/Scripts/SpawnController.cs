using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    
    public GameObject obstacle;
    public GameObject addPlayer;
    public GameObject blank;
    public Transform worldContainer;
    private GameObject newestObject;
    private bool spawnNew = true;
    private bool first = true;

	// Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (spawnNew) {
            spawnNew = false;
            var spawnPosX = Random.Range(-2, 3);
            Vector3 newPos = Vector3.zero;
            if (first) {
                first = false;
                newPos = new Vector3(spawnPosX, 0, 30);
            } else {
                newPos = new Vector3(spawnPosX, 0, newestObject.transform.position.z + 1);
            }
            var spawnWhich = Random.Range(0, 6);
            if (spawnWhich >= 1 && spawnWhich <= 3) {
                newestObject = Instantiate(obstacle, newPos, Quaternion.identity, worldContainer);
            } else if (spawnWhich == 0) {
                newestObject = Instantiate(addPlayer, newPos, Quaternion.identity, worldContainer);
            } else {
                newestObject = Instantiate(blank, newPos, Quaternion.identity, worldContainer);
            }
        }
        if(newestObject.transform.position.z <= 29){
            spawnNew = true;
        }
	}
}
