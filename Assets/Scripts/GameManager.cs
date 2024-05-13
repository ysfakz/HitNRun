using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private int score;
    private float gamePlayingTimer;
    private float gamePlayingTimerMax = 10f;
    private enum State {
        WaitingToStart,
        GamePlaying,
        GameOver,
    }

    private State currentState;

    private void Awake() {
        currentState = State.WaitingToStart;
    }


    private void Start() {
        gamePlayingTimer = gamePlayingTimerMax;
        FindWaitingToStartUI();
    }

    private void Update() {
        FindWaitingToStartUI();

        switch (currentState) {
            case State.WaitingToStart:
                Time.timeScale = 1f;
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer <= 0f) {
                    currentState = State.GameOver;
                }
                break;
            case State.GameOver:
                Time.timeScale = 0f;
                break;
        }
        
    }

    private void FindWaitingToStartUI() {
        WaitingToStartUI waitingToStartUI = FindObjectOfType<WaitingToStartUI>();
        if (waitingToStartUI != null) {
            waitingToStartUI.OnStartPressed += WaitingToStartUI_OnStartPressed;
        }
    }

    private void WaitingToStartUI_OnStartPressed(object sender, EventArgs e) {
        currentState = State.GamePlaying;
    }

    public void Scored() {
        score++;
    }

    public int GetScore() {
        return score;
    }

    public float GetGamePlayingTimerNormalized() {
        return 1 - (gamePlayingTimer / gamePlayingTimerMax);
    }

    public bool IsWaitingToStart() {
        return currentState == State.WaitingToStart;
    }

    public bool IsGamePlaying() {
        return currentState == State.GamePlaying;
    }

    public bool IsGameOver() {
        return currentState == State.GameOver;
    }

}
