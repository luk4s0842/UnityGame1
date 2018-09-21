using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPos : MonoBehaviour {
    private RectTransform rectTransform;
    public Canvas canvas;

    // Use this for initialization
    void Start() {
        Debug.Log(Screen.width);
        rectTransform = transform.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchoredPosition = new Vector2(Screen.width / 8 / canvas.scaleFactor, 150);
        Debug.Log(Screen.width / canvas.scaleFactor / 8 - rectTransform.rect.width / 2);
        Debug.Log(150 * canvas.scaleFactor);
        if (Screen.width / canvas.scaleFactor / 8 - rectTransform.rect.width/2 < 150 * canvas.scaleFactor){
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, Screen.width / canvas.scaleFactor / 8 - rectTransform.rect.width / 2 + rectTransform.rect.height/2);
        }
    }

}
