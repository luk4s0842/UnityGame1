using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour {
    public Transform playersContainer;
    private PlayerMovement playerMovement;
    public SpawnController spawnController;

    private bool gameHasStarted;



    public ScoreManager scoreManager;
    public TextMeshProUGUI bestScoreText;

    // Buttons
    public RectTransform restartButton;
    public RectTransform shopButton;
    public RectTransform noAdsButton;
    public RectTransform leaderboardButton;
    public RectTransform soundButtonOn;
    public RectTransform soundButtonOff;


    // Specials
    public Image freePrize;
    public Image adCoins;
    public Image rateGame;
    public Image winPrize;



    void Start () {
        playerMovement = playersContainer.GetComponent<PlayerMovement>();
        scoreManager = playersContainer.GetComponent<ScoreManager>();
        ZPlayerPrefs.Initialize("lukas0842", "43FT423FF343FWDEF4332DDE");


        if (ZPlayerPrefs.GetInt("NotFirstLaunch") == 0){
            ZPlayerPrefs.SetInt("SoundIsOn", 1);
            ZPlayerPrefs.SetInt("BestScore", 0);

            ZPlayerPrefs.SetInt("NotFirstLaunch", 1);
        }

        if (ZPlayerPrefs.GetInt("SoundIsOn") == 1){
            soundButtonOn.gameObject.SetActive(true);
            soundButtonOff.gameObject.SetActive(false);
        } else {
            soundButtonOn.gameObject.SetActive(false);
            soundButtonOff.gameObject.SetActive(true);
        }
    }
	
	void Update () {

	}

    public void GameOver() {
        Debug.Log("GAME OVER");
        playerMovement.enabled = false;
        spawnController.enabled = false;
        restartButton.gameObject.SetActive(true);
        bestScoreText.gameObject.SetActive(true);


        // Specials
        SetParentChildren(freePrize.gameObject, true);
        SetParentChildren(adCoins.gameObject, true);
        SetParentChildren(rateGame.gameObject, true);
        SetParentChildren(winPrize.gameObject, true);

        // save highscore if greater than old highscore
        if (scoreManager.score > ZPlayerPrefs.GetInt("BestScore")){
            ZPlayerPrefs.SetInt("BestScore", scoreManager.score);
        }
        bestScoreText.text = "BEST: " + ZPlayerPrefs.GetInt("BestScore");
    }


    public void StartGame() {
        Debug.Log("START GAME");
        playerMovement.enabled = true;
        spawnController.enabled = true;
        shopButton.gameObject.SetActive(false);
        noAdsButton.gameObject.SetActive(false);
        leaderboardButton.gameObject.SetActive(false);
        soundButtonOn.gameObject.SetActive(false);
        soundButtonOff.gameObject.SetActive(false);
        bestScoreText.gameObject.SetActive(false);

        // Specials
        SetParentChildren(freePrize.gameObject, false);
        SetParentChildren(adCoins.gameObject, false);
        SetParentChildren(rateGame.gameObject, false);
        SetParentChildren(winPrize.gameObject, false);
    }


    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void TurnSoundOn() {
        soundButtonOn.gameObject.SetActive(true);
        soundButtonOff.gameObject.SetActive(false);
        ZPlayerPrefs.SetInt("SoundIsOn", 1);
    }
    public void TurnSoundOff(){
        soundButtonOn.gameObject.SetActive(false);
        soundButtonOff.gameObject.SetActive(true);
        ZPlayerPrefs.SetInt("SoundIsOn", 0);
    }


    private void SetParentChildren(GameObject parent, bool state) {
        parent.SetActive(state);
        foreach (Transform child in parent.transform) {
            child.gameObject.SetActive(state);
        }
    }

}
