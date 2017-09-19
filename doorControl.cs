using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class doorControl : MonoBehaviour {
    private bool doorIsOpening = false; // variable to show if the door's current state.
    public GameObject Door; // gameObject variable to control the door
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if(doorIsOpening==true) // if door is opening
        {
            if(Door.transform.position.y<10) // and the door's current y position is less than 10
            Door.transform.Translate(Vector3.up * Time.deltaTime * 5); // move the door up until its y position is 10 
            gameObject.GetComponent<Renderer>().material.color = Color.blue; // change the color of the button to blue

        }
        else
        { if(Door.transform.position.y>2.5) // else if the door is closing
            Door.transform.Translate(Vector3.down * Time.deltaTime * 5); // move the door down until its y position is 2.5
            gameObject.GetComponent<Renderer>().material.color = Color.red; // change the color of the button to red

        }
    }
    private void OnMouseDown() // called when the button is clicked
    {
        if (doorIsOpening == true) // if doorIsOpening is already true
        {
            doorIsOpening = false; // close the door
        }
        else  
        {
            doorIsOpening = true; // else open the door
        }
    }
}
