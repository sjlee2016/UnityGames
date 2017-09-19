using UnityEngine;
using UnityEngine.UI;

public class WinZone : MonoBehaviour
{
    public GameObject message;
    //has the player won; checked by other scripts
    public bool won { get; set; }

    // Use this for initialization
    void Start()
    {
        won = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            message.SetActive(true);

            if (other.gameObject.GetComponent<CollectibleCounter>().count >= other.gameObject.GetComponent<CollectibleCounter>().countLimit)
            {
                message.GetComponent<Text>().text = "You Win!";
                won = true;
            }
            else
            {
                message.GetComponent<Text>().text = "Collect more orbs!";
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            message.SetActive(false);
        }
    }
}