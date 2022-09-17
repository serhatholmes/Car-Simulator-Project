using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCameraController : MonoBehaviour
{
    [SerializeField] List<Camera> cameras;
    public int camIndex = 0;

    private void Start() {
        cameras[camIndex].enabled = true;
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
        cameras[camIndex].enabled = false;
        cameras[index].enabled = true;
        camIndex = index;
    }
}
