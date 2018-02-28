/*
 Se Jin Lee
 ID: sejlee
 Chapman email : sejlee@chapman.edu
 Experimental Course Fall 2017 CPSC 229-01
 Final Project
 * 
 * randomly spawns the two collectibles inside the house ( heart, drink ) 
 * */
using System;
using UnityEngine;

public class Randomize : MonoBehaviour
{
    // For spawn area
    public Vector3 center;
    public Vector3 size;

    // Collectible objects
    public GameObject food;
    public GameObject water;

    // Min/max number of each collectible, per spawn area
    public uint minNumFood;
    public uint minNumWater;
    public uint maxNumFood ;
    public uint maxNumWater;
    // Render scale of each collectible object
    public float foodScale ;
    public float waterScale;
    public bool empty= false;
    // For monitoring how many spawn in Unity
    public uint numFood;
    public uint numWater;
    void Start() // spawn the food at the start of the game
    {
        spawn();
    }

    void spawn() 
    {
        // Only spawn collectibles if min/max values are valid
        if (minNumFood <= maxNumFood && minNumWater <= maxNumWater)
        {
            center = gameObject.transform.position;
            // randomly generate numFood and numWater
            numFood = (uint)UnityEngine.Random.Range((float)minNumFood, (float)maxNumFood);
            numWater = (uint)UnityEngine.Random.Range((float)minNumWater, (float)maxNumWater);

            SpawnFood(); // spawn food and water
            SpawnWater();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Entered");
    }

    void OnTriggerExit(Collider col) // once the player leaves the house, empty is set to true
    {
        //if(col.CompareTag("Player"))
        empty = true;
    }
    void Update() {
        if(empty==true) // if empty is true
        {
            Debug.Log("spawned");
            Invoke("spawn", 100); // respawn food and drink after 100 seconds
            empty = false;
        }
    }

    public void SpawnCollectible(GameObject obj)
    {
        // Choose random position within GameObject holding script
        Vector3 position = center + new Vector3(UnityEngine.Random.Range(-size.x / 2, size.x / 2), UnityEngine.Random.Range(-size.y / 2, size.y / 2), UnityEngine.Random.Range(-size.z / 2, size.z / 2));

        // Spawn item at position with its normal rotation
        Instantiate(obj, position, obj.transform.rotation);
    }

    void SpawnFood() // spawns food gameobject that is scaled to foodScale 
    {
        for (int i = 0; i < numFood; ++i)
        {
            food.transform.localScale = new Vector3(foodScale, foodScale, foodScale);
            SpawnCollectible(food);
        }
    }

    void SpawnWater()// spawns water gameobject that is scaled to foodScale 
    {
        for (int i = 0; i < numWater; ++i)
        {
            water.transform.localScale = new Vector3(waterScale, waterScale, waterScale);
            SpawnCollectible(water);

        }
    }


    // Quickly draw cube that bounds spawn area while GameObject is selected in hierarchy
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawCube(gameObject.transform.position, size);
    }
}

