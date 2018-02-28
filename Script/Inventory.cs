using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public Button[] buttons;
	public Button closeBtn;
	public Image inventoryBackground;
	public Button backpackBtn;
    public GameObject player;
	public List<GameObject> currentInventory;
	public Sprite emptySlot;

    public GameObject chicken, water;
	private GameManager gm;
    
	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
        
    }

	
	// Update is called once per frame
	void Update () {
		
	}

	public void UseItem(int slotNumber){
		Debug.Log ("Slot " + slotNumber + " clicked!");
		if (currentInventory.Count-1 >= slotNumber) {
			if (currentInventory [slotNumber].GetComponent<Item> ()) {
				currentInventory [slotNumber].GetComponent<Item> ().transform.position = gm.playerHands.gameObject.transform.position;
				currentInventory [slotNumber].GetComponent<Item> ().transform.rotation = Quaternion.identity;
				currentInventory [slotNumber].gameObject.SetActive (true);
				currentInventory [slotNumber].gameObject.GetComponent<Item> ().DropDown ();
				buttons [slotNumber].gameObject.GetComponentInChildren<Text> ().text = "Empty";
				buttons [slotNumber].gameObject.GetComponent<Image> ().sprite = emptySlot;
				currentInventory.RemoveAt (slotNumber);
				ActivateInventory ();
				UpdateBackpackIcons ();
			} else {
				Debug.Log ("Slot " + slotNumber + " is empty.");
			}
		} else {
			Debug.Log ("Inventory is empty");
		}
	}
    public void ConsumeItem(int slotNumber)
    {
        if (currentInventory.Count - 1 >= slotNumber)
        {
            if (currentInventory[slotNumber].GetComponent<Item>())
            {
                if(currentInventory[slotNumber].GetComponent<Item>().CompareTag("Chicken"))
                {
                    player.GetComponent<HealthManager>().increaseHeart();
                }else
                {
                    player.GetComponent<HealthManager>().increaseWaterLevel();
                }
                buttons[slotNumber].gameObject.GetComponentInChildren<Text>().text = "Empty";
                buttons[slotNumber].gameObject.GetComponent<Image>().sprite = emptySlot;
                currentInventory.RemoveAt(slotNumber);
                ActivateInventory();
                UpdateBackpackIcons();
            }
            else
            {
                Debug.Log("Slot " + slotNumber + " is empty.");
            }
        }
        else
        {
            Debug.Log("Inventory is empty");
        }
    }
    public void AddItem(GameObject itemToAdd){
		currentInventory.Add (itemToAdd);
		UpdateBackpackIcons ();
	}
	void UpdateBackpackIcons(){
		for(var i = 0; i < currentInventory.Count; i++){
			if (currentInventory [i].GetComponent<Item> ()) {
				buttons [i].gameObject.GetComponentInChildren<Text> ().text = currentInventory [i].gameObject.GetComponent<Item> ().name;
				buttons [i].gameObject.GetComponent<Image> ().sprite = currentInventory [i].gameObject.GetComponent<Item> ().itemImage;
			}
		}
	}
	public void ActivateInventory(){
		backpackBtn.gameObject.SetActive (false);
		for (var i = 0; i < buttons.Length; i++) {
			buttons [i].gameObject.SetActive (true);
			buttons[i].gameObject.GetComponentInChildren<Text> ().text = "Empty";
			buttons[i].gameObject.GetComponent<Image> ().sprite = emptySlot;
		}
		closeBtn.gameObject.SetActive (true);
		inventoryBackground.gameObject.SetActive (true);
		UpdateBackpackIcons ();
	}

	public void DeactivateInventory(){
		backpackBtn.gameObject.SetActive (true);
		for(var i = 0; i < buttons.Length; i++){
			buttons[i].gameObject.SetActive (false);
		}
		closeBtn.gameObject.SetActive (false);
		inventoryBackground.gameObject.SetActive (false);
	}
}
