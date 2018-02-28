/*
 Se Jin Lee
 ID: sejlee
 Chapman email : sejlee@chapman.edu
 Experimental Course Fall 2017 CPSC 229-01
 Final Project
 * 
 * attached to the player to keep track of collectibles 
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour {
    public int numFood = 0;  // variables that keep the number of food and water collected
    public int numWater = 0;
    public int total = 0;
	// Use this for initialization
    void Update()
    {
        total = numFood + numWater;  // total is calculated so when it is 9, the player no longer can
                                        //collect more food from the ground
    }
	public int returnTotal()  // return total;
    {
        return total;
    }
    public void addFood() // increase food
    {
        numFood++;
    }
    public void addWater() // increase water
    {
        numWater++;
    }
    public void decreaseFood() // decrease food
    {
        if(numFood>0)
        {
            numFood--;
        }
    }
    public void decreaseWater() // decrease water
    {
        if(numWater>0)
        {
            numWater--;
        }
    }
}
