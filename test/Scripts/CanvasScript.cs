using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] public float speedFloat;
    [SerializeField] public TextMeshProUGUI speed;
    [SerializeField] public TextMeshProUGUI remainHook;
    [SerializeField] GrapplingGun grappleGunScript;
    public static CanvasScript instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        remainHook.text = "Remaining Hook:"+" "+grappleGunScript.remainingHook;
        speed.text = "Move Speed:" + Math.Round(GetComponent<Rigidbody>().velocity.magnitude,2).ToString();
    }
}
