using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {

    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private TextMeshProUGUI totalPointsText;

    private void Awake() {
        restartButton.onClick.AddListener(() => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
        menuButton.onClick.AddListener(() => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        });
    }

    private void Start() {
        gameOverUI.gameObject.SetActive(false);
    }

    private void Update() {
        if (gameManager.IsGameOver()) {
            gameOverUI.gameObject.SetActive(true);
        }
        totalPointsText.text = "Total Points: " + gameManager.GetScore();
    }

}
