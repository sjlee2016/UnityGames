using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
    //GameObject to hold our timer
    public GameObject timerGO;
    public int timer;
    // variable to set the amount of play time before the player loses
    public int timeLimit;
    public GameObject gameOverScreen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Let's test some different time functions
        timer = (int)Time.realtimeSinceStartup;
        timerGO.GetComponent<Text>().text = "Time : " + timer.ToString();
		if(timer >= timeLimit)
        {
            // then we want to end the game.
            Debug.Log("Game is Over");
            gameOverScreen.SetActive(true);
        }
	}
}
