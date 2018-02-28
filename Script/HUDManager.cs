using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDManager : MonoBehaviour {
    public Image heart1, heart2, heart3;
    public Sprite fullheart, emptyHeart;
    public GameObject player;
    // Use this for initialization
    int previousHeart = 3;
    int currentHeart;
    public void setHeart(int heart)
    {
        currentHeart = heart;
    }
    // Update is called once per frame
    void Update()
    {
        
        currentHeart = player.GetComponent<HealthManager>().getHeart();
        if (previousHeart != currentHeart)
        {
            switch (currentHeart)
            {
                case 1:
                    heart1.sprite = fullheart;
                    heart3.sprite = emptyHeart;
                    heart2.sprite = emptyHeart; break;
                case 2:
                    heart1.sprite = fullheart;
                    heart2.sprite = fullheart;
                    heart3.sprite = emptyHeart; break;
                case 3:
                    heart3.sprite = fullheart;
                    heart2.sprite = fullheart;
                    heart3.sprite = fullheart; break;
             

            }
           
            previousHeart = currentHeart;
        }
    }
}
