using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour {

    // real swipe vars
    public bool tap, swipeLeft, swipeRight;
    private bool isDragging;
    private Vector2 startTouch, swipeDelta;

    private void Update() {
        tap = swipeLeft = swipeRight = false;

        if (Input.touches.Length > 0) {
            if (Input.touches[0].phase == TouchPhase.Began) {
                isDragging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            } else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) {
                isDragging = false;
                Reset();
            }
        }

        // calc distance
        swipeDelta = Vector2.zero;
        if (isDragging) {
            if (Input.touches.Length > 0) {
                swipeDelta = Input.touches[0].position - startTouch;
            }


            // crossing dead zone
            if (swipeDelta.magnitude > 80) {
                // Direction
                float x = swipeDelta.x;
                float y = swipeDelta.y;

                if (Mathf.Abs(x) > Mathf.Abs(y)) {
                    if (x < 0) {
                        Debug.Log("left true");
                        swipeLeft = true;
                    } else {
                        Debug.Log("right true");
                        swipeRight = true;
                    }
                }
                Reset();
            }
        }
    }

    private void Reset() {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }
}
