using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fall : MonoBehaviour
{
    public float fallingSpeed;
    public bool isFalling, collideFloor;
    public GameObject player;
    public GameObject timeManager;
    private int counter;
    private int countLimit;

    // Use this for initialization
    void Start()
    {
        collideFloor = false;
        isFalling = false;
        countLimit = player.GetComponent<CollectibleCounter>().countLimit;
    }

    // Update is called once per frame
    void Update()
    {
        //all collectibles have been collected

        counter = player.GetComponent<CollectibleCounter>().count;

        if (counter == countLimit && !collideFloor)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }

        if (isFalling)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - fallingSpeed, gameObject.transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (other.gameObject.tag=="Floor")
        {
            collideFloor = true;
        }
    }
}