using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingTextUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI loadingText;
    private float interval = 0.35f;
    private string baseText = "LOADING";
    private int maxDots = 3;

    private void Start() {
        StartCoroutine(AddDots());
    }

    private IEnumerator AddDots() {
        while (true) {
            for (int i = 0; i <= maxDots; i++) {
                loadingText.text = baseText + new string('.', i);
                yield return new WaitForSeconds(interval);
            }
        }
    }
}
