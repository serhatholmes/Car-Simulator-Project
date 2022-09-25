using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCameraController : MonoBehaviour
{
    [SerializeField] List<Camera> cameras;
    public int camIndex = 0;

    private void Start() {

        //3 different camera angles can be changed with 1-2-3 keys
        //Having them all on at startup lowers fps

        cameras[0].enabled = true;
        cameras[1].enabled = false;
        cameras[2].enabled = false;
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            SwapCamera(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            SwapCamera(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)){
            SwapCamera(2);
        }
    }

    private void SwapCamera(int index){

        //other camera turns off on camera change
        cameras[camIndex].enabled = false;
        cameras[index].enabled = true;
        camIndex = index;
    }
}
