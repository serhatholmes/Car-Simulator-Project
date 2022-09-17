using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float accelPower;
    [SerializeField] [Range(0, 1)] float tractionMultiplier;
    private float driftingMagnitude;
    private Vector3 rightVelocity;
    private Vector3 forwardVelocity;
    [SerializeField] float turnPower;

    private Rigidbody rb;


    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    private void Update() {

        forwardVelocity = transform.forward * Vector3.Dot(rb.velocity, transform.forward);
        driftingMagnitude = Vector3.Dot(rb.velocity, transform.right);
        rightVelocity = transform.right * driftingMagnitude;

        rb.velocity = forwardVelocity + rightVelocity * tractionMultiplier + new Vector3(0, rb.velocity.y, 0);


        if (Input.GetKey(KeyCode.W)){
            rb.AddForce(transform.forward * accelPower, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S)){
            rb.AddForce(transform.forward * -accelPower, ForceMode.Force);
        }

        float turnAdjuster = rb.velocity.magnitude / 16f;
        turnAdjuster = Mathf.Clamp01(turnAdjuster);

        if (Input.GetKey(KeyCode.A)){
            transform.localEulerAngles -= Vector3.up * turnPower/2f * turnAdjuster;
        }

        if (Input.GetKey(KeyCode.D)){
            transform.localEulerAngles += Vector3.up * turnPower/2f * turnAdjuster;
        }
    }
}
