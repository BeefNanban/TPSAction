using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SunLight : MonoBehaviour {

    [SerializeField]
    private float rotate = 0.1f;
    [SerializeField]
    private Vector3 rot = new Vector3(270f, 330f, 0f);

	// Use this for initialization
	void Start () {
        transform.localRotation = Quaternion.Euler(rot);
        var rotX = transform.localEulerAngles.x - 15f * DateTime.Now.Hour;

        if(rotX < 0)
        {
            rotX += 360f;
        }
        transform.localEulerAngles = new Vector3(rotX, transform.localEulerAngles.y, transform.localEulerAngles.z);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(-Vector3.right * rotate * Time.deltaTime);
	}
}
