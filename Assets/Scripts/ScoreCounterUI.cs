using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounterUI : MonoBehaviour {

    [SerializeField] GameManager gameManager;
    [SerializeField] private TextMeshProUGUI scoreCounterText;
    private void Update() {
        scoreCounterText.text = gameManager.GetScore().ToString();
    }

}
