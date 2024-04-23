using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedometerUI : MonoBehaviour {
    [SerializeField] private CarMovement car;
    [SerializeField] private TextMeshProUGUI speedometerText;

    void Update() {
        speedometerText.text = "Speed: " + car.GetCurrentSpeed();
    }
}
