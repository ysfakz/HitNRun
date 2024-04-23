using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class CarMovement : MonoBehaviour {
    // public Vector3 position;
    public float moveSpeed = 500f;
    public float reverseSpeed = -200f;
    public float maxReverseSpeed = -300f;
    public float maxMoveSpeed = 600f;
    public Rigidbody rb;
    public Vector3 moveDir;
    public Transform orientation;
    private void Update() {
        if (Input.GetKey(KeyCode.Q)) {
            
        }
        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(gameObject.transform.forward * moveSpeed * 10f, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S)) {
            rb.AddForce(gameObject.transform.forward * reverseSpeed * 10f, ForceMode.Acceleration);
        }
        // if (Input.GetKey(KeyCode.A)) {
        //     moveDir = orientation.forward + orientation.right;
        //     rb.AddForce(-moveDir * moveSpeed * 10f, ForceMode.Force);
        // }
        // if (Input.GetKey(KeyCode.D)) {
        //     moveDir = orientation.forward + orientation.right;
        //     rb.AddForce(moveDir * moveSpeed * 10f, ForceMode.Force);
        // }
        LimitSpeed();
    }

    private void LimitSpeed() {
        float currentSpeed = rb.velocity.magnitude;
        // if (moveSpeed > maxMoveSpeed) {
        //     moveSpeed = maxMoveSpeed;
        // }
        // if (reverseSpeed > maxReverseSpeed) {
        //     reverseSpeed = maxReverseSpeed;
        // }
        if (GetCurrentSpeed() > maxMoveSpeed) {
            currentSpeed = maxMoveSpeed;
        }
        if (GetCurrentSpeed() > maxReverseSpeed) {
            currentSpeed = maxReverseSpeed;
        }
    }

    public int GetCurrentSpeed() {
        return (int)rb.velocity.magnitude;
    }
}
