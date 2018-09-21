using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAddPlayer : MonoBehaviour {
    
    private Vector3 highestPlayerPos = new Vector3(0, -10, 0);
    private Transform highestPlayer;
    private Transform playersContainer;
    private ScoreManager scoreManager;

    private void Start() {
        playersContainer = GameObject.Find("PlayersContainer").transform;
        scoreManager = playersContainer.GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other) {
        foreach(Transform player in playersContainer){
            if(player.position.y > highestPlayerPos.y){
                highestPlayerPos = player.position;
                highestPlayer = player;
            }
        }

        if (other.tag == "Player"){
            scoreManager.score++;

            Transform newPlayer = Instantiate(highestPlayer, new Vector3(highestPlayerPos.x, highestPlayer.transform.position.y+1, highestPlayerPos.z), Quaternion.identity);
            newPlayer.parent = playersContainer;
            if(newPlayer.gameObject.GetComponent<FixedJoint>()){
                Destroy(newPlayer.GetComponent<FixedJoint>());
            }
            FixedJoint joint = highestPlayer.gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = newPlayer.GetComponent<Rigidbody>();
            Destroy(gameObject);
        }
    }

}
