using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarController2 : MonoBehaviour {
    [SerializeField] private GameManager gameManager;
    public static event EventHandler OnPlayerScored;
    private float moveInput;
    private float turnInput;
    public float collisionForce = 1000f;
    public float movementSpeed;
    public float reverseSpeed;
    public float turnSpeed;
    public Rigidbody rb;

    private void Start() {
        rb.transform.parent = null;
    }

    private void Update() {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        transform.position = rb.transform.position;
        moveInput *= moveInput > 0 ? movementSpeed : reverseSpeed;

        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.Rotate(0, newRotation, 0, Space.World);
    }

    private void FixedUpdate() {
        rb.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Person")) {
            Rigidbody personRb = collision.gameObject.GetComponent<Rigidbody>();
            if (personRb != null) {
                gameManager.Scored();
                OnPlayerScored?.Invoke(this, EventArgs.Empty);
            }
        }
    }

}
