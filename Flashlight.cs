using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Flashlight : MonoBehaviour {
    //Bool to track if flashlight is on
    public bool isOn;
    //Gameobject for turning on/off the flashlight
    public GameObject flashlight;
    // Messagesfor when our flashlight is turned on and off
    public string lightOnText;
    public string lightOffText;
    // This is the gameobject that holds the text for the flashlight
    public GameObject lightText;
    public GameObject counterText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Detect user input for the "f" key
       
        if (Input.GetKeyDown(KeyCode.F)) {
            Debug.Log("User hit F");
            if (isOn){
                isOn = false;
                flashlight.SetActive(false);
                lightText.GetComponent<Text>().text = lightOffText;
                Invoke("ResetText", 5f);
            }
            //Else, we turn our light on
            else {
                isOn = true;
                flashlight.SetActive(true);

                lightText.GetComponent<Text>().text = lightOnText;
                Invoke("ResetText", 5f);
            }
        }
     
    }
    private void ResetText()
    {
        
        lightText.GetComponent<Text>().text = "";
    }

}
