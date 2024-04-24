using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreModalUI : MonoBehaviour {
    [SerializeField] GameManager gameManager;
    [SerializeField] private Transform modal;
    [SerializeField] private TextMeshProUGUI scoreCounterText;
    private void Awake() {
        modal.gameObject.SetActive(false);
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            modal.gameObject.SetActive(true);
        } else if (Input.GetKeyUp(KeyCode.Tab)) {
            modal.gameObject.SetActive(false);
        }

        if (modal.gameObject.activeSelf) {
            scoreCounterText.text = gameManager.GetScore().ToString();
        }
    }
}
