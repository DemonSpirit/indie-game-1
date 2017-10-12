using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
    int maxSteps = 1800;
    int step = 0;
    public string gameState = "start";
    public float[,] inputArray = new float[1800 , 4];

	// Use this for initialization
	void Start () {
        gameState = "live";
        //initialise array values.
        for (int i = 0; i < maxSteps; i++)
        {
            for (int ii = 0; ii < 4; ii++)
            {
                inputArray[i, ii] = 0;
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
        switch (gameState)
        {   
            case "live":
                inputArray[step, 0] = Input.GetAxis("Horizontal");
                inputArray[step, 1] = Input.GetAxis("Vertical");
                step++;
                break;

            case "playback":
                break;
        }
        
    }
}
