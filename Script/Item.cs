using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : MonoBehaviour {
    public GameObject player;
    public GameObject parent, dropzone;
    public AudioSource drop;
    public AudioSource Collect;
	public string name;
    public float currentTime, previousTime;
	public GameObject prefab;
	public int itemID;
	public bool collectible;
    public bool ableToCollect = true;
    public float collectDistance = 3;
	public Sprite itemImage;
    public bool firstTime = true;
    public List<GameObject> currentInventory;

    private GameManager gm;

	private Rigidbody rb;

	void Awake(){
	
	}

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
        
            getKey();
         
	}
    void getKey()
    {
        if (Input.GetKeyDown(KeyCode.Z) && collectible == true && player.GetComponent<collectible>().returnTotal() < 9)
        {
            currentTime += Time.deltaTime;
            if (this.gameObject.CompareTag("Chicken"))
            {
                player.GetComponent<collectible>().addFood();
            }
            else if (this.gameObject.CompareTag("Water"))
            {
                player.GetComponent<collectible>().addWater();
            }
            Collect.Play();
            gm.inventory.AddItem(this.gameObject);
            parent.SetActive(false);

        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        collectible = true;
    }
    void OnTriggerExit(Collider col)
    {
        collectible = false;
    }

    public void DropDown()
    {
        drop.Play();
        if (this.gameObject.CompareTag("Chicken"))
        {
            player.GetComponent<collectible>().decreaseFood();
        }
        else if (this.gameObject.CompareTag("Water"))
        {
            player.GetComponent<collectible>().decreaseWater();
        }

        
          Invoke ("Drop", 1f);
          
       GameObject ob = Instantiate(prefab, dropzone.transform.position, Quaternion.identity);
        ob.SetActive(true);
        
    }
    public void reset()
    {
        ableToCollect = true;
    }
	public void Drop(){
        
        Invoke("reset", 1f);
    }
}
