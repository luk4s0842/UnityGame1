using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public bool playerCantMoveLeft = false;
    public bool playerCantMoveRight = false;
    public bool isTouchingLeftWall = false;
    public bool isTouchingRightWall = false;



    // animation
    float lerpTime;
    float currentLerpTime;
    float perc = 1;

    Vector3 startPos;
    Vector3 endPos;

    private bool firstInput;
    private bool canMove = true;

    public SwipeController swipeController;


    // Update is called once per frame
    void Update () {

        if (swipeController.swipeLeft || swipeController.swipeRight) {
            Debug.Log("SOME SWIPE");
            if (perc == 1) {
                lerpTime = 1;
                currentLerpTime = 0;
                firstInput = true;
            }
        }

        // Mobile movement
        if (swipeController.swipeRight){
            Debug.Log("SWIPE RIGHT");
            if (canMove && playerCantMoveRight == false && isTouchingRightWall == false) {
                endPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            }
        }
        if(swipeController.swipeLeft){
            Debug.Log("SWIPE LEFT");
            if (canMove && playerCantMoveLeft == false && isTouchingLeftWall == false) {
                endPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            }
        }




        // Keyboard movement


        if (Input.GetButtonDown("GoLeft") || Input.GetButtonDown("GoRight")){
            if(perc == 1){
                lerpTime = 1;
                currentLerpTime = 0;
                firstInput = true;
            }
        }

        startPos = gameObject.transform.position;


        if (Input.GetButtonDown("GoLeft") && playerCantMoveLeft == false && isTouchingLeftWall == false) {
            if (canMove) {
                endPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            }
        }

        if (Input.GetButtonDown("GoRight") && playerCantMoveRight == false && isTouchingRightWall == false) {
            if (canMove) {
                endPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            }
        }

        if (firstInput) {
            canMove = false;
            currentLerpTime += Time.deltaTime * 8F;
            perc = currentLerpTime / lerpTime;
            gameObject.transform.position = Vector3.Lerp(startPos, endPos, perc);
            if(perc >= 1){
                perc = 1;
                canMove = true;
            }
            //if(Mathf.Round(perc) == 1){
            //    justJumped = false;
            //}
        }
	}
}
