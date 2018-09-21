using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour {

    public Rigidbody obstacleRb;
    public float speed;


    private void Start() {
    }

    // Update is called once per frame
    void FixedUpdate () {
        obstacleRb.MovePosition(transform.position - transform.forward * speed * Time.deltaTime);
	}
}
