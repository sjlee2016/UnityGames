/*
 Se Jin Lee
 ID: sejlee
 Chapman email : sejlee@chapman.edu
 Experimental Course Fall 2017 CPSC 229-01
 Final Project
 * controls the death scene.
 * death scene is played after 2 seconds after death
 * which displays how many days he/she survived 
 * */
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameOverManager : MonoBehaviour {
    public Text dayText;
	// Use this for initialization
	public void Restart() // called when restart button is clicked
    {
        SceneManager.LoadScene("Menu");
    }
    void Start() // call setText when the gameOver scene is loaded
    {
        setText();
    }
    public void setText()  // display the number of days the player survived
    {
        int day = PlayerPrefs.GetInt("Day");
        dayText.text = "You survived for " + day + " days";
    }
}
