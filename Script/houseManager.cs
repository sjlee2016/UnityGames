/*
 Se Jin Lee
 ID: sejlee
 Chapman email : sejlee@chapman.edu
 Experimental Course Fall 2017 CPSC 229-01
 Final Project
 * 
 * controls the house
 * when the player collides with the house object ( gets in the house)
 * the environment temperature of the player increases
 * and when the player exits ( leaves the house) it decreases.
 * Environment temperature is used to know if the player's body temperature
 * should increase or decrease
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class houseManager : MonoBehaviour {

    public GameObject player;
    public AudioSource warm;
    public AudioSource cold;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            cold.Stop();
            warm.Play();
            player.GetComponent<HealthManager>().increaseEnviro();


        }
    }

    void OnTriggerExit(Collider col)
    {
        player.GetComponent<HealthManager>().decreaseEnviro();
    }
}
