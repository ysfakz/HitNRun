using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    [SerializeField] private GameObject thirdPersonCamera;
    [SerializeField] private Transform thirdPersonCameraLocation;

    private void Update() {
        thirdPersonCamera.transform.position = thirdPersonCameraLocation.position;
        thirdPersonCamera.transform.rotation = thirdPersonCameraLocation.rotation;
    }
}
