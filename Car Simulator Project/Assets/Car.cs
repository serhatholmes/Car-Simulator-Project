using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float accelPower;
    [SerializeField] float turnPower;

    private Rigidbody rb;


    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    private void Update() {
        if (Input.GetKey(KeyCode.W)){
            rb.AddForce(transform.forward * accelPower, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S)){
            rb.AddForce(transform.forward * -accelPower/2f, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.A)){
            transform.localEulerAngles -= Vector3.up * turnPower;
        }

        if (Input.GetKey(KeyCode.D)){
            transform.localEulerAngles += Vector3.up * turnPower;
        }
    }
}
