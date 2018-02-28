/*
 Se Jin Lee
 ID: sejlee
 Chapman email : sejlee@chapman.edu
 Experimental Course Fall 2017 CPSC 229-01
 Final Project
 * 
 * controls the body temperature of the player 
 * and displays it accordingly
 * the player's temperature drops outside the house
 * and if the temperature drops to 0, the player dies
 * */
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tempManager : MonoBehaviour {

    public Text tempText;
    public GameObject player;
    public float coldTime = 0;
    public int currentBodyTemp = 3;
    public int previousBodyTemp = 0;
    public float secondsInCold, secondsInWarm = 0;
    private string warm = "warm";
    private string medium = "medium";
    private string cold = "cold";
    public int currentEnviro = 0;
    public int previousEnviro = 1;
    private int minuteCount;
    public bool firstTime = true;
    public int switchFlag = 0;
    public void setTemp(int temp)
    {
        currentBodyTemp = temp;
    }
    public int getTemp()
    {
        return currentBodyTemp;
    }
    void Update()
    {
        currentEnviro = player.GetComponent<HealthManager>().getenviroTemp();
       // get the environment temperature.
       //  0 is outside the house  1 is inside
        updateTempUI();
        if (currentEnviro ==0 )
        {
            updateTimeinCold(); // if the player is outside the house, he/she gets cold
        }else
        {
            updateTimeinWarm();  // if the player is inside the house, he/she gets warm
        }
      
    }
    
    void getCold() // decrease temperature
    {

        player.GetComponent<HealthManager>().decreaseTemp();

    }
    void getWarm() // increase temperature
    {
        player.GetComponent<HealthManager>().increaseTemp();
       
    }
    //call this on update

    public void updateTempUI() // display the temperature on the screen
    {
        currentBodyTemp = player.GetComponent<HealthManager>().getTemp();
        if (currentBodyTemp != previousBodyTemp) // if the temperature has changed
        {
            tempText.text = "temp : "; // change the text
            switch (currentBodyTemp)
            {
                case 1: tempText.text += cold; break;
                case 2: tempText.text += medium; break;
                case 3: tempText.text += warm; break;
            }
            previousBodyTemp = currentBodyTemp;
        }
           
    }
    public void updateTimeinCold() // called when the player is outside the house
    {

        //set timer UI
        
        secondsInCold += Time.deltaTime;
        if (secondsInWarm > 0)
        {
            secondsInWarm -= Time.deltaTime;
        }
        if (secondsInCold >= 30)  // the player loses temperature every 30 seconds he is outside the house
        {
            getCold();
            secondsInCold = 0;
           
        }
       
       
    }

    public void updateTimeinWarm () // player's temperature increases when inside the house
    {
        secondsInWarm += Time.deltaTime;
        if(secondsInCold>0)
        {
            secondsInCold -= Time.deltaTime;
        }
        if (secondsInWarm >= 15) // increases every 15 seconds
        {
            getWarm();
            secondsInWarm = 0;
        }
    }
}
