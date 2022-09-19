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

    public bool carMoving = false;

    public bool blink = false;


    private void Start() {

        carMoving = true;

        spotLightL.enabled = false;
        spotLightR.enabled = false;

        signalLightL.enabled = false;
        signalLightR.enabled = false;

        backLightL.enabled = false;
        backLightR.enabled = false;

        
        carSound.PlayOneShot(engineStartSound);
    }

    private void Update() {

        if(carMoving == true){

            carSound.clip = engineSound;
            carSound.loop = true;
            carSound.Play();
        }
        
        if(Input.GetKeyDown(KeyCode.H)){

            carSound.PlayOneShot(hornSound);
        }

        if(Input.GetKeyDown(KeyCode.L)){

            if(spotLightL.enabled == false && spotLightR.enabled == false){
                spotLightL.enabled = true;
                spotLightR.enabled = true;
            }else{
                spotLightL.enabled = false;
                spotLightR.enabled = false;
            }
            
        }
    }

    public void signalLeft(){
        if(!blink){
            blink = true;
            StartCoroutine(BlinkLightL());
        }
            
        else{
            blink = false;
            signalLightL.enabled = false;
        }
            
    }
    public void signalRight(){
        if(!blink){
            blink = true;
            StartCoroutine(BlinkLightR());
        }
            
        else{
            blink = false;
            signalLightR.enabled = false;
        }
    }

    private IEnumerator BlinkLightL(){

        while(blink){
            signalLightL.enabled = true;
            yield return new WaitForSeconds(0.5f);
            signalLightL.enabled = false;
        }
        
    }

    private IEnumerator BlinkLightR(){

        while(blink){
            signalLightR.enabled = true;
            yield return new WaitForSeconds(0.5f);
            signalLightR.enabled = false;
        }
    }

}
