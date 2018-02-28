/*
 Se Jin Lee
 ID: sejlee
 Chapman email : sejlee@chapman.edu
 Experimental Course Fall 2017 CPSC 229-01
 Final Project
 * 
 * displays death UI when the player dies from cold, hunger or thirst.
 * death scene is played after 2 seconds, which displays how many days he/she survived 
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class deathManager : MonoBehaviour {
    public GameObject deathUI;
   // public GameObject winUI;
    public GameObject timeManager;
    // Use this for initialization
    public void death() // called when the player dies
    {
       
        deathUI.SetActive(true); // display death image
        PlayerPrefs.SetInt("Day", timeManager.GetComponent<timeManager>().getDay());
        // save the number of days survived
        Invoke("quitGame", 2);
        // load to gameOver scene
    }
    /*public void win()  // was planning to make Win scene when the day passes over 30, but 
     *                                  // my unity crashed.... I will do this over the break
    {
        winUI.SetActive(true);
        Invoke("winGame", 2);
    }*/
    public void quitGame() // load to gameOver scene
    {
        SceneManager.LoadScene("gameOver");
    }
    /*
    public void winGame()
    {
        SceneManager.LoadScene("win");
    }*/

}
