using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerUI : MonoBehaviour {

    [SerializeField] private Image timerImage;
    [SerializeField] private GameManager gameManager;

    private void Update() {
        timerImage.fillAmount = gameManager.GetGamePlayingTimerNormalized();
    }

}
