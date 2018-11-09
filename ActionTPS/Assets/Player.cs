using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Animator anim;
    public float walkspeed;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 target_dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if(target_dir.magnitude > 0.1)
        {
            transform.rotation = Quaternion.LookRotation(target_dir);
            
            transform.Translate(Vector3.forward * Time.deltaTime * walkspeed);
            anim.SetBool("walk",true);
            anim.SetBool("run", true);
     
        }
        else
        {
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
        }
	}
}
