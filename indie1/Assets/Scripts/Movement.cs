using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public CharacterController characterCtrlr;
	public float moveSpd;
	public Vector3 moveDirection = Vector3.zero;
	public float jumpSpd = 16f;
	public float gravity = 20f;
	public Vector3 camOffset = Vector3.zero;
	public Camera cam;
    public bool active = false;
    GameObject gameCtrlr;
    float h, v;

	// Use this for initialization
	void Start () {
		characterCtrlr = GetComponent<CharacterController> ();
        gameCtrlr = GameObject.Find("GameControl");
		camOffset = cam.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (active == true)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        } else
        {

        }
		

		//call fmod event : footstep.event

		if (characterCtrlr.isGrounded == true) 
		{	
			moveDirection = new Vector3 (h, 0, v);
			if (Input.GetButton ("Jump")) 
			{
				moveDirection.y = jumpSpd;
			}
		} else
		{	moveDirection.x = h;
			moveDirection.z = v;
			moveDirection.y -= gravity*Time.deltaTime;
		}
			
		moveDirection.x *= moveSpd;
		moveDirection.z *= moveSpd;
		moveDirection = transform.TransformDirection (moveDirection);
		characterCtrlr.Move (moveDirection *  Time.deltaTime);

		SetCameraOffset ();




	}

	void SetCameraOffset()
	{	cam.transform.position = transform.position + camOffset;
	}
}
