using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeColor : MonoBehaviour {

    public Renderer player;
    Color colorToLerp = new Color(0.42F, 0.42F, 0.42F);

    private float duration = 1.6F;
    private float t = 0;

	// Update is called once per frame
	void Update () {
        player.material.color = Color.Lerp(player.material.color, colorToLerp, t);
        t += Time.deltaTime / duration;
        if (t >= 1){
            enabled = false;
        }
	}
}
