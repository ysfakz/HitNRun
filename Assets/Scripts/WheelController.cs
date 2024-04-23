using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour {

    [SerializeField] private WheelCollider frontLeftWheel;
    [SerializeField] private WheelCollider frontRightWheel;
    [SerializeField] private WheelCollider rearLeftWheel;
    [SerializeField] private WheelCollider rearRightWheel;
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    public float acceleration = 500f;
    public float brakingForce = 300f;
    public float maxTurnAngle = 15f;
    public float decelerationRate = 200f;

    private float currentAcceleration = 0f;
    private float currentBrakeForce = 0f;
    private float currentTurnAngle = 0f;

    private bool isAccelerating = false;

    public void FixedUpdate() {

        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Q)) {
            currentBrakeForce = brakingForce;
        } else {
            currentBrakeForce = 0f;
        }

         // Check if accelerating or decelerating
        if (currentAcceleration > -1 || currentAcceleration < 1) {
            isAccelerating = true;
        } else {
            isAccelerating = false;
        }

        // Apply braking force if not accelerating
        if (!isAccelerating) {
            currentBrakeForce = Mathf.Min(decelerationRate * Time.deltaTime, brakingForce); // Gradual deceleration
        } else {
            currentBrakeForce = 0f;
        }
    
        //move forward
        frontLeftWheel.motorTorque = currentAcceleration;
        frontRightWheel.motorTorque = currentAcceleration;

        //brake
        frontLeftWheel.brakeTorque = currentBrakeForce;
        frontRightWheel.brakeTorque = currentBrakeForce;
        rearLeftWheel.brakeTorque = currentBrakeForce;
        rearRightWheel.brakeTorque = currentBrakeForce;
        
        //steering
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeftWheel.steerAngle = currentTurnAngle;
        frontRightWheel.steerAngle = currentTurnAngle;

        UpdateVisual(frontLeftWheel, frontLeftWheelTransform);
        UpdateVisual(frontRightWheel, frontRightWheelTransform);
        UpdateVisual(rearLeftWheel, rearLeftWheelTransform);
        UpdateVisual(rearRightWheel, rearRightWheelTransform);

    }

    private void UpdateVisual(WheelCollider collider, Transform transform) {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        transform.position = position;
        transform.rotation = rotation;
    }

}
