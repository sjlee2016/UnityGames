/*
 Se Jin Lee
 ID: sejlee
 Chapman email : sejlee@chapman.edu
 Experimental Course Fall 2017 CPSC 229-01
 Final Project
 * even though it is called healthmanager,
 * this script controls all of player's health(heart), temperature, waterlevel, environmentTemperature
 * 
 * */
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {
    public int maxHeart = 3;
    public int enviroTemp = 0;
    public int maxTemp = 3;
    public int maxWaterlevel = 4;
    public int currentTemp = 3;
    public int currentHeart = 3;
    public int currentWaterlevel = 4;
    public GameObject player;
    public AudioSource damaged, healed, eating, drinking;
    public float time;
    public AudioSource coldVoice;
    public AudioSource warmVoice;
    public bool firstTime = true;
    // Use this for initialization
    
    public int getenviroTemp()
    {
        return enviroTemp;
    }
    public int getTemp()
    {
        return currentTemp;
    }
    public int getHeart()
    {
        return currentHeart;
    }

    public int getWaterlevel()
    {
        return currentWaterlevel;
    }
    public void increaseTemp() // increases temperature
    {
        if(currentTemp<maxTemp) // do not increase if already max
            currentTemp += 1;

        if (currentTemp != 1)  // if temp is not 1
        {
            coldVoice.Stop(); // play warm voice and stop cold voice
            warmVoice.Play();
        }
    }
    public void increaseEnviro() // this is called when the player steps inside the house
    {
        enviroTemp = 1; // enviroTemp == 1 when inside the house
                        // == 0 outside the house.
                        // the player loses his body temp only when enviroTemp == 0
    }

    public void increaseWaterLevel() // called when water is consumed
    {
        drinking.Play();
        if (currentWaterlevel < maxWaterlevel) // increase only when lower than max
            currentWaterlevel += 1;
    }
    public void increaseHeart() // called when chicken is consumed
    {
        eating.Play();

        if (currentHeart < maxHeart) // increase only when lower than max
            currentHeart += 1;
    }
    public void decreaseEnviro() // called when player steps out of the house
    {
        warmVoice.Stop();
        enviroTemp = 0;
    }
    public void decreaseHeart() // decreases heart. This function is called every 2 days(2 minutes)
    {
        if (currentHeart > 1) // decrease when bigger than 1
        {
            currentHeart -= 1;
        }
        else
        {           // else the player dies from hunger
            player.GetComponent<deathManager>().death();
        }
}
    

    public void decreaseWaterLevel()// decreases waterLevel. called once a day ( 1 minute)
    {
        if (currentWaterlevel > 1) // decrease when bigger than 1
            currentWaterlevel -= 1;
        else
            player.GetComponent<deathManager>().death(); // die if waterLevel == 0
    }

    public void decreaseTemp() // decreases temperature. called after every 30 seconds in cold climate(out side the house)
    {
        if (currentTemp >  1)
        {
            currentTemp -= 1;
        }
        else
            player.GetComponent<deathManager>().death(); // dies if temp becomes  0
        if(currentTemp==1)
        {
            warmVoice.Stop();
            coldVoice.Play();
        }
    }
}
