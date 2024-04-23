using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] GameObject firstPersonCamera;
    [SerializeField] GameObject thirdPersonCamera;
    [SerializeField] GameObject topDownCamera;

    private void Awake() {
        thirdPersonCamera.SetActive(false);
        firstPersonCamera.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SwitchCamera();
        }
    }

    private void SwitchCamera() {
        if (topDownCamera.activeSelf) {
            topDownCamera.SetActive(false);
            thirdPersonCamera.SetActive(true);
        }
        else if (thirdPersonCamera.activeSelf) {
            thirdPersonCamera.SetActive(false);
            firstPersonCamera.SetActive(true);
        }
        else if (firstPersonCamera.activeSelf) {
            firstPersonCamera.SetActive(false);
            topDownCamera.SetActive(true);
        }
    }
}
