/*
 Se Jin Lee
 ID: sejlee
 Chapman email : sejlee@chapman.edu
 Experimental Course Fall 2017 CPSC 229-01
 Final Project
 * 
 * used to manage player's waterLevel.
 * maximum is 4.
 * it decreases every minute.
 * the player needs to consume water to increase it
 * when it drops to 0, the player dies
 */
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waterManager : MonoBehaviour {
    public Sprite waterLevel1, waterLevel2, waterLevel3, waterLevel4;
    // Use this for initialization
    public int previousLevel = 4;
    public int currentLevel;
    public GameObject player;
    public Image waterlevel;
    public void setWater(int water)
    {
        currentLevel = water;
    }
    public int getWater()
    {
        return currentLevel;
    }
    // Update is called once per frame
    void Update () {
        currentLevel = player.GetComponent<HealthManager>().getWaterlevel();
        // when there is a change in the water level, update the UI
        if (previousLevel != currentLevel)
        {
            switch (currentLevel) // change the sprite accordinly
            {
                case 1:
                    waterlevel.sprite = waterLevel1;
                    break;
                case 2:
                    waterlevel.sprite = waterLevel2;
                    break;
                case 3:
                    waterlevel.sprite = waterLevel3;
                    break;
                case 4:
                    waterlevel.sprite = waterLevel4;
                    break;


            }

            previousLevel = currentLevel;
        }
    }
}

