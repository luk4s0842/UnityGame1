﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Obstacle" || other.tag == "AddPlayer" || other.tag == "Player" || other.tag == "Blank"){
            Destroy(other.gameObject);
        }
    }
}
