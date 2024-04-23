using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private int score;
    private float gamePlayingTimer;
    private float gamePlayingTimerMax = 100f;

    private void Start() {
        gamePlayingTimer = gamePlayingTimerMax;
    }

    private void Update() {
        gamePlayingTimer -= Time.deltaTime;
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

}
