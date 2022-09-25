using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearTransmission : MonoBehaviour
{
    public bool isGoingForward = false;
    public bool isGoingBackward = false;
    CarController carController;
    private void Start() {
        
        carController = GetComponent<CarController>();
    }
    // for forward,backward and park gear
    public void forwardGear(){
        isGoingForward = true;
    }
    public void backGear(){
        isGoingBackward = true;
        isGoingForward = false;
    }
    public void parkGear(){

        isGoingBackward = false;
        isGoingForward = false;
    }
}
