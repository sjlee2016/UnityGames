using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CounterDisplay : MonoBehaviour {
    public string beginning;
    public GameObject counter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        counter.GetComponent<Text>().text = beginning + counter.GetComponent<CollectibleCounter>().count;
	}
}
