using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarController : MonoBehaviour
{
    public bool isMoving = false;
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

    [SerializeField] Transform frontLeftWheel;
    [SerializeField] Transform frontRightWheel;

    private float steerInput;

    public Rigidbody rb;

    public GearTransmission gearTransmission;

    [SerializeField] Slider Fuel;
    [SerializeField] TMP_Text fuelPercent;

    public bool isGoingBack = false;


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

            // eğer yakıt varsa ileri ve geri fonksiyonları aktif oluyor

                if(gearTransmission.isGoingForward == true){

                    gearTransmission.isGoingBackward = false;

                    if (Input.GetKey(KeyCode.W)){
                    rb.AddForce(transform.forward * accelPower, ForceMode.Force);
                    Fuel.value -= 0.02f * Time.deltaTime; // yakıt zamana bağlı olarak azalmakta
                    fuelPercent.text = "Fuel: % " + Mathf.RoundToInt((Fuel.value * 100)).ToString();
                    isGoingBack = false; // geri ışığın yanmaması için

                }
            }

                if(gearTransmission.isGoingBackward == true){

                    gearTransmission.isGoingForward = false;

                    if (Input.GetKey(KeyCode.S)){
                    rb.AddForce(transform.forward * -accelPower, ForceMode.Force);
                    Fuel.value -= 0.02f * Time.deltaTime;
                    fuelPercent.text = "Fuel: % " +  Mathf.RoundToInt((Fuel.value * 100)).ToString();
                    isGoingBack = true;
                }else{
                    isGoingBack = false; // geri ışığı tuştan elini kaldırınca yanmaması için
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
            
        steeringWheel.rectTransform.localEulerAngles = new Vector3(0, 0, -steerInput * 60f); // ekrandaki direksiyonun dönüşüne yansıtmak için
        frontLeftWheel.localEulerAngles  = new Vector3(0, steerInput * 45f, 0); // dönüşü ön teker objelerine yansıtmak için
        frontRightWheel.localEulerAngles = new Vector3(0, steerInput * 45f, 0);
    }
}

    private void OnTriggerEnter(Collider other) {

        // aracın pistte attığı tam türün süresini öğrenmek için

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
