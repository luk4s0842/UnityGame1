using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    private PlayerMovement playerMovement;
    private bool playerCantMove;
    public bool isDisabled;
    public Transform gameController;
    private GameController gameControllerScript;

    private void Start() {
        Transform playersContainer = transform.parent;
        playerMovement = playersContainer.GetComponent<PlayerMovement>();

        gameControllerScript = gameController.GetComponent<GameController>();
    }

    private void OnCollisionStay(Collision collision) {
        if(isDisabled == false){
            if (collision.collider.tag == "Obstacle") {
                float xPlayerPos = transform.position.x;
                float xColliderPos = collision.transform.position.x;
                float yPlayerPos = transform.position.y;
                float yColliderPos = collision.transform.position.y;
                if (xPlayerPos > xColliderPos && yColliderPos + 0.97 > yPlayerPos && yColliderPos - 0.97 < yPlayerPos) {
                    playerMovement.playerCantMoveLeft = true;
                } else if (xPlayerPos < xColliderPos && yColliderPos + 0.97 > yPlayerPos && yColliderPos - 0.97 < yPlayerPos) {
                    playerMovement.playerCantMoveRight = true;
                }
            }
        }


        if (collision.collider.tag == "Wall") {
            if (collision.collider.transform.position.x > transform.position.x) {
                playerMovement.isTouchingRightWall = true;
            } else {
                playerMovement.isTouchingLeftWall = true;
            }
        }
    }


    private void OnCollisionEnter(Collision collision) {
        if (transform.parent) {
            foreach (Transform player in transform.parent) {
                player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
        }
        if (collision.collider.tag == "Obstacle"){
            float xPlayerPos = transform.position.x;
            float xColliderPos = collision.transform.position.x;
            if(xPlayerPos > xColliderPos-1 && xPlayerPos < xColliderPos+1  && transform.position.y < collision.collider.transform.position.y+0.95 && collision.transform.position.z > transform.position.z){
                if (xPlayerPos > xColliderPos + 0.95) {
                    transform.parent.position = new Vector3(xColliderPos + 1F, transform.parent.position.y, transform.parent.position.z);
                    GetComponent<Rigidbody>().velocity = Vector3.zero;
                    GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    return;
                } else if (xPlayerPos < xColliderPos - 0.95) {
                    transform.parent.position = new Vector3(xColliderPos - 1, transform.parent.position.y, transform.parent.position.z);
                    GetComponent<Rigidbody>().velocity = Vector3.zero;
                    GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    return;
                }

                if (transform.parent.childCount == 1) {
                    gameControllerScript.GameOver();
                }


                isDisabled = true;


                if (transform.position.y > collision.collider.transform.position.y + 0.80) {
                    transform.position = new Vector3(transform.position.x, collision.collider.transform.position.y + 0.80F, transform.position.z);
                }

                if (xPlayerPos > xColliderPos + 0.8){
                    transform.position = new Vector3(xColliderPos + 0.8F, transform.position.y, transform.position.z);
                } else if (xPlayerPos < xColliderPos - 0.8) {
                    transform.position = new Vector3(xColliderPos - 0.8F, transform.position.y, transform.position.z);
                }
                transform.position = new Vector3(transform.position.x, transform.position.y, collision.collider.transform.position.z-1);
                Destroy(GetComponent<FixedJoint>());
                GetComponent<Rigidbody>().mass = 0;

                GetComponent<StayOnZ>().enabled = false;
                GetComponent<FadeColor>().enabled = true;
                transform.parent = null;
                enabled = false;
            }
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.collider.tag == "Obstacle") {
            playerMovement.playerCantMoveLeft = false;
            playerMovement.playerCantMoveRight = false;
        }
        if (collision.collider.tag == "Wall"){
            playerMovement.isTouchingLeftWall = false;
            playerMovement.isTouchingRightWall = false;
        }
    }

    private float GetFloat1DP(float number){
        return Mathf.Round(number * 10f) / 10f;
    }
}
