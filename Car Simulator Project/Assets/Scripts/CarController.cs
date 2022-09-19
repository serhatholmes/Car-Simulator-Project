using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarController : MonoBehaviour
{
    [SerializeField] float accelPower;
    float startTime, endTime;
    float lapTime;
    bool lapStarted = false;
    [SerializeField] [Range(0, 1)] float tractionMultiplier;
    private float driftingMagnitude;
    private Vector3 rightVelocity;
    private Vector3 forwardVelocity;
    [SerializeField] float turnPower;
    [SerializeField] RawImage steeringWheel;

    private float steerInput;

    private Rigidbody rb;

    [SerializeField] Slider Fuel;
    [SerializeField] TMP_Text fuelPercent;


    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    private void Update() {

        float forwardScaler = Vector3.Dot(rb.velocity, transform.forward);
        forwardVelocity = transform.forward * forwardScaler;
        driftingMagnitude = Vector3.Dot(rb.velocity, transform.right);
        rightVelocity = transform.right * driftingMagnitude;

        rb.velocity = forwardVelocity + rightVelocity * tractionMultiplier + new Vector3(0, rb.velocity.y, 0);

        if(Fuel.value > 0){

            if (Input.GetKey(KeyCode.W)){
                rb.AddForce(transform.forward * accelPower, ForceMode.Force);
                Fuel.value -= 0.02f * Time.deltaTime;
                fuelPercent.text = "Fuel: % " + Mathf.RoundToInt((Fuel.value * 100)).ToString();
            }
            if (Input.GetKey(KeyCode.S)){
                rb.AddForce(transform.forward * -accelPower, ForceMode.Force);
                Fuel.value -= 0.02f * Time.deltaTime;
                fuelPercent.text = "Fuel: % " +  Mathf.RoundToInt((Fuel.value * 100)).ToString();
            }
        }

        

        float turnAdjuster = rb.velocity.magnitude / 16f;
        turnAdjuster = Mathf.Clamp01(turnAdjuster);

        if (Input.GetKey(KeyCode.A)){
            steerInput = Mathf.Lerp(steerInput, -1f, Time.deltaTime * 4f);
        }
        else if (Input.GetKey(KeyCode.D)){
            steerInput = Mathf.Lerp(steerInput, 1f, Time.deltaTime * 4f);
        }
        else{
            steerInput = Mathf.Lerp(steerInput, 0f, Time.deltaTime * 4f);
        }

        if (forwardScaler >= 0)
            transform.localEulerAngles += Vector3.up * steerInput * turnPower/1.5f * turnAdjuster;
        else
            transform.localEulerAngles -= Vector3.up * steerInput * turnPower/1.5f * turnAdjuster;
            
        steeringWheel.rectTransform.localEulerAngles = new Vector3(0, 0, -steerInput * 60f);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Finish Line")){
            if (!lapStarted){
                startTime = Time.time;
                lapStarted = true;
            }
            else{
                endTime = Time.time;
                lapStarted = false;
                lapTime = endTime - startTime;
                Debug.Log(lapTime);
            }
        }
    }
}
