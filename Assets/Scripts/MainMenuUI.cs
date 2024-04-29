using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {

    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Transform loadingScreen;

    private void Awake() {
        loadingScreen.gameObject.SetActive(false);
    }

    private void Update() {
        playButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.GameScene);
            loadingScreen.gameObject.SetActive(true);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });
        quitButton.onClick.AddListener(() => {
            Application.Quit();
        });
    }

}
