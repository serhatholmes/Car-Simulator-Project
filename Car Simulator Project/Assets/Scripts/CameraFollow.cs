using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform targetObj;
    [SerializeField] float followCoeff;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] Vector3 offset;
    private void LateUpdate() {
        transform.position = targetObj.position + targetObj.right * offset.x + targetObj.up * offset.y + targetObj.forward * offset.z;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.LerpAngle(transform.localEulerAngles.y, targetObj.localEulerAngles.y, followCoeff), 0);
    }
}
