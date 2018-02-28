using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuButtonManager : MonoBehaviour {

	// Use this for initialization
	public void startGame()
    {
        SceneManager.LoadScene("LiveIfYouCan");

    }
    // Update is called once per frame
    public void quitGame()
    {
        Application.Quit();
    }
}
