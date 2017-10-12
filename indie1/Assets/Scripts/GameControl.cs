using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
    public int maxSteps = 1800;
    int step = 0;
    int layer = 0;
    public string gameState = "start";
    public float[,] inputArray = new float[1800 , 4];
    public GameObject playerPrefab;
    public Vector3 spawnPos;
    public GameObject activeInst;
	// Use this for initialization
	void Start () {
        gameState = "live";
        layer++;
        
	}
	
	// Update is called once per frame
	void Update () {
        switch (gameState)
        {
            case "start":
                activeInst = Instantiate(playerPrefab, spawnPos, Quaternion.identity);
                activeInst.GetComponent<Movement>().active = true;
                step = 0;
                layer++;
                gameState = "live";
                
                break;
            case "live":
                inputArray[step, 0] = Input.GetAxis("Horizontal");
                inputArray[step, 1] = Input.GetAxis("Vertical");
                step++;
                if (step >= 1800) gameState = "end";
                break;

            case "playback":
                break;

            case "end":
                activeInst.active = false;
                break;

        }
        
    }
}
