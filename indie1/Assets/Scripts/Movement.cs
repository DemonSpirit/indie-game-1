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
    GameControl gameCtrl;
    float h, v;

    int maxSteps;
    float[,] inputArray = new float[1800, 4];

	// Use this for initialization
	void Start () {
		characterCtrlr = GetComponent<CharacterController> ();
        camOffset = cam.transform.position - transform.position;

        GameObject gamecontrollerObj = GameObject.Find("GameControl");
        gameCtrl = gamecontrollerObj.GetComponent<GameControl>();

        //initialise array values.
        for (int i = 0; i < gameCtrl.maxSteps; i++)
        {
            for (int ii = 0; ii < 4; ii++)
            {
                inputArray[i, ii] = 0;
            }

        }
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
