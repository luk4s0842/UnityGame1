using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //#pragma strict
    public Transform player;  // Drag your player here
    private Vector2 fp;  // first finger position
    private Vector2 lp;  // last finger position

    // Update is called once per frame
    void Update() {
        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                fp = touch.position;
                lp = touch.position;
            }
            if (touch.phase == TouchPhase.Moved) {
                lp = touch.position;
            }
            if (touch.phase == TouchPhase.Ended) {
                if ((fp.x - lp.x) > 80){ // LEFT
                    Debug.Log("LEFT");
                    player.position = new Vector3(player.position.x - 1, player.position.y, player.position.z);
                } else if ((fp.x - lp.x) < -80){ // RIGHT
                    Debug.Log("RIGHT");
                    player.position = new Vector3(player.position.x + 1, player.position.y, player.position.z);
                }
            }
        }
    }
}