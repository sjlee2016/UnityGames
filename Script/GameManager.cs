/*
 Se Jin Lee
 ID: sejlee
 Chapman email : sejlee@chapman.edu
 Experimental Course Fall 2017 CPSC 229-01
 Final Project
 * 
 * enables the character to use certain keys to control their movement 
 * I key is used to open/close the inventory
 * Keypad 0~9 is used to consume food at that inventory number
 * 
 * */
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Inventory inventory;
	public GameObject player;
	public GameObject playerHands;
    public bool inventoryOpened;
    public AudioSource invenSound;
	// Use this for initialization
	void Start () {
		FindPlayer ();
        inventoryOpened = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) // if the key I is pressed
        {
            if (inventoryOpened == false) // if inventory is not open
            {
                inventory.GetComponent<Inventory>().ActivateInventory();
                inventoryOpened = true; // open the inventory and set the variable to true
            }
            else  // if inventory is closed, open it and set inventoryOpened to false
            {
                inventory.GetComponent<Inventory>().DeactivateInventory();
                inventoryOpened = false;
            }
            invenSound.Play();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1)) // if 1 is pressed, the first item is consumed
        {
            inventory.GetComponent<Inventory>().ConsumeItem(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // if 2 is pressed, the second item is consumed
        {
            inventory.GetComponent<Inventory>().ConsumeItem(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // and so on..
        {
            inventory.GetComponent<Inventory>().ConsumeItem(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            inventory.GetComponent<Inventory>().ConsumeItem(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            inventory.GetComponent<Inventory>().ConsumeItem(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            inventory.GetComponent<Inventory>().ConsumeItem(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            inventory.GetComponent<Inventory>().ConsumeItem(6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            inventory.GetComponent<Inventory>().ConsumeItem(7);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            inventory.GetComponent<Inventory>().ConsumeItem(8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            inventory.GetComponent<Inventory>().ConsumeItem(9);
        }
    }

	void FindPlayer(){
		player = GameObject.FindGameObjectWithTag ("Player");
	}
}
