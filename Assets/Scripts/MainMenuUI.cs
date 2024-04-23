using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {

    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Update() {
        playButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.GameScene);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });
        quitButton.onClick.AddListener(() => {
            Application.Quit();
        });
    }

}
