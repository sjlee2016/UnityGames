/*
 Se Jin Lee
 ID: sejlee
 Chapman email : sejlee@chapman.edu
 Experimental Course Fall 2017 CPSC 229-01
 Final Project
 * 
 * attached to the button manager that managed the ? button
 * if ? is clicked, page 1 appears, which explains the controls
 * the next button is clicked, page 1 is turned to page 2, which explains the goal of the game
 * 
 * 
 * */
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class buttonManager : MonoBehaviour {
    public bool opened = false;
    public int page = 0;
    public AudioSource flip;
    public GameObject page1, page2, page3;
	// Use this for initialization
	public void click() // called when  ? button is clicked
    {
        if(opened==false) // if it is not opened
        {
            displayUI(1);
            flip.Play(); // sound of page flip
            opened = true;
        }else
        { // if the page 1 is already open
            displayUI(0);
            flip.Play();
            opened = false;
        }
    }
    public void displayUI(int i)
    {
        switch(i)
        {
            case 0:
                page = 0;
                page1.SetActive(false);
                page2.SetActive(false);
                page3.SetActive(false); break;
            case 1:
                page = 1;
                page1.SetActive(true);
                page2.SetActive(false);
                page3.SetActive(false);
                break;
            case 2:
                page = 2;

                page1.SetActive(false);
                page2.SetActive(true);
                page3.SetActive(false);
                break;
            case 3:
                page = 3;
                page1.SetActive(false);
                page2.SetActive(false);
                page3.SetActive(true);
                break;
        }
    }
    public void previous()
    {
        if(page==2)
        {
            displayUI(1);

            flip.Play();
        }
        else if(page==3)
        {
            displayUI(2);

            flip.Play();
        }
    }
    public void next()// called when the next button is clicked
    {
        if(page==1) // if in page 1, turn to page 2
        {
            displayUI(2);
            flip.Play();
        }
        else if(page==2)
        {           // turn to next page
            displayUI(3);
            flip.Play();
        }
    }
}
