using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour {

    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform gamePausedScreen;

    private void Awake() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            gameManager.TogglePauseGame();
        }
    }

    private void Start() {
        gamePausedScreen.gameObject.SetActive(false);

        gameManager.OnGamePaused += GameManager_OnGamePaused;
        gameManager.OnGameUnpaused += GameManager_OnGameUnpaused;
    }

    private void GameManager_OnGamePaused(object sender, EventArgs e) {
        Show();
    }

    private void GameManager_OnGameUnpaused(object sender, EventArgs e) {
        Hide();
    }

    private void Show() {
        gamePausedScreen.gameObject.SetActive(true);
    }

    private void Hide() {
        gamePausedScreen.gameObject.SetActive(false);
    }

}
