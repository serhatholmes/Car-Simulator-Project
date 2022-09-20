using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFeatures : MonoBehaviour
{
    [SerializeField] AudioSource carSound;
    [SerializeField] AudioClip hornSound;
    [SerializeField] AudioClip engineStartSound;
    [SerializeField] AudioClip engineSound;

    [SerializeField] Light spotLightL;
    [SerializeField] Light spotLightR;
    [SerializeField] Light signalLightL;
    [SerializeField] Light signalLightR;
    [SerializeField] Light backLightL;
    [SerializeField] Light backLightR;

    public bool signallingLeft = false, signallingRight = false;

    public bool carMoving = false;

    public bool blink = false;

    public CarController carController;


    private void Start() {

        carMoving = true;

        spotLightL.enabled = false;
        spotLightR.enabled = false;

        signalLightL.enabled = true;
        signalLightR.enabled = true;
        signalLightL.intensity = 0;
        signalLightR.intensity = 0;

        backLightL.enabled = false;
        backLightR.enabled = false;

        
        carSound.PlayOneShot(engineStartSound);
    }

    private void Update() {

        
        if(Input.GetKeyDown(KeyCode.H)){

            carSound.PlayOneShot(hornSound);
        }

        if(Input.GetKeyDown(KeyCode.L)){

            // farların açılıp kapanması için

            if(spotLightL.enabled == false && spotLightR.enabled == false){
                spotLightL.enabled = true;
                spotLightR.enabled = true;
            }else{
                spotLightL.enabled = false;
                spotLightR.enabled = false;
            }
            
        }

        if (signallingLeft){
            signalLightL.intensity = Mathf.RoundToInt(Mathf.PingPong(Time.time*2f, 1f));
        }
        if (signallingRight){
            signalLightR.intensity = Mathf.RoundToInt(Mathf.PingPong(Time.time*2f, 1f));
        }

        // geri ışıkları
        if(carController.isGoingBack){
            backLightL.enabled = true;
            backLightR.enabled = true;
        }else{
            backLightL.enabled = false;
            backLightR.enabled = false;
        }
    }

    // sinyal ışıkları
    public void signalLeft(){
        signallingLeft = !signallingLeft;
        signalLightL.intensity = 0;
    }

    public void signalRight(){
        signallingRight = !signallingRight;
        signalLightR.intensity = 0;
    }

}
