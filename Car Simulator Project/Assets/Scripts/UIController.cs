using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] Rigidbody carRb;

    [SerializeField] TextMeshProUGUI velocityText;

    private void Update() {
        // hız göstergesi 
        velocityText.text = "Hız: " + Mathf.RoundToInt(carRb.velocity.magnitude) + " km/s";
    }
}
