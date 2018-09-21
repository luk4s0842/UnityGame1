using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {


    private TextMeshProUGUI textMesh;
    private ScoreManager scoreManager;
    public Transform playersContainer;

	// Use this for initialization
	void Start () {
        textMesh = GetComponent<TextMeshProUGUI>();
        scoreManager = playersContainer.GetComponent<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
        textMesh.text = scoreManager.score.ToString();
	}
}
