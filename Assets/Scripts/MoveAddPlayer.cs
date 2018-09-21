using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAddPlayer : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
    void FixedUpdate() {
        transform.Translate(-transform.forward * speed * Time.deltaTime);
    }
}
