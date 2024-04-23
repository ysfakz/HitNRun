using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour {
    [SerializeField] private GameObject firstPersonCamera;
    [SerializeField] private Transform firstPersonCameraLocation;

    private void Update() {
        firstPersonCamera.transform.position = firstPersonCameraLocation.position;
        firstPersonCamera.transform.rotation = firstPersonCameraLocation.rotation;
    }
}
