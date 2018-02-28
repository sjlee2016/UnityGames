/*
 Se Jin Lee
 ID: sejlee
 Chapman email : sejlee@chapman.edu
 Experimental Course Fall 2017 CPSC 229-01
 Final Project
 * 
 * calculates the time in Days and display it.
 * In this game, a day is 1 minute in real time
 * makes the player's health decrease 1 every 2 days and 
 * decrease waterLevel once a day
 * seconds are displayed as morning(0~19),afternoon(20~39) and night(40~59) 
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class timeManager : MonoBehaviour
{
    public Text timerText;
    public int days;
    private int hungryCount=0;
    private int thirstyCount=0;
    public GameObject player;
    private float secondsCount;
    private string t = "morning";
    private int minuteCount;
    public int getDay()
    {
        return days;
    }
    void Update()
    {
        UpdateTimerUI();
    }
    void getHungry() // called every 2 minutes in real time
    {
          // the player gets hungry and so the heart decreases
            player.GetComponent<HealthManager>().decreaseHeart();

    }
    void getThirtsty() // called every minute in real time
    {
        // the player gets thirsty and so the waterlevel drops
        player.GetComponent<HealthManager>().decreaseWaterLevel();
        Debug.Log("called");
    }
    //call this on update
    public void UpdateTimerUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        timerText.text = "day " + days + "\n" + t;
       // timerText.text = hourCount + "h:" + minuteCount + "m:" + (int)secondsCount + "s";
        if (secondsCount >= 60)
        {
            minuteCount++;
            if (hungryCount == 1) // called every 2 minutes
            {
                getHungry();
                hungryCount = 0;

            }
            getThirtsty(); // called every minute
            hungryCount++;
            thirstyCount++;
            secondsCount = 0;
        }
        days = minuteCount; // convert minute to days
        if(days==10) // player wins when days is 10
        {
            SceneManager.LoadScene("win");
        }
        if(secondsCount>=0&&secondsCount<=20) // display the seconds 
        {
            t = "morning";
        }else if(secondsCount>20&&secondsCount<=40)
        {
            t = "afternoon";
        }else if(secondsCount>40 && secondsCount <60)
        {
            t = "night";
        }
    }
}