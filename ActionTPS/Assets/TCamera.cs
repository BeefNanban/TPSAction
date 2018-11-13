using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCamera : MonoBehaviour {
    public Transform Target;

    public float XYDistance = 0f;
    public float DistancePlayer = 2f;
    public float Height = 1.2f;
    public float RotationK = 100;
    public float cameraSpeed;

    // Use this for initialization
    void Start () {
        if (Target == null)
        {
            Application.Quit();
        }
    }
	
	// Update is called once per frame
	void Update () {
        var rotX = Input.GetAxis("Mouse X") * Time.deltaTime * cameraSpeed * RotationK;
        var rotY = Input.GetAxis("Mouse Y") * Time.deltaTime * cameraSpeed * RotationK;

        var lookAt = Target.position + Vector3.up * Height;

        transform.RotateAround(lookAt, Vector3.up, rotX);

        if (transform.forward.y > 0.9f && rotY < 0)
        {
            rotY = 0;
        }
        if (transform.forward.y < -0.9f && rotY > 0)
        {
            rotY = 0;
        }
        transform.RotateAround(lookAt, transform.right, rotY);
        transform.position = lookAt - transform.forward * DistancePlayer;

        transform.LookAt(lookAt);
        transform.position = transform.position + transform.right * XYDistance;
    }
}
