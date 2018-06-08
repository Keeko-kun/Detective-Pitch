using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    static private int mode;
    private string modeString;
    public UnityEngine.UI.Text modeText;
    public int sceneload;

	// Use this for initialization
	void Start ()
	{
	    mode = 2;
	    modeString = "Medium";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeMode(int newMode)
    {
        mode = newMode;
        switch (mode)
        {
            case 1:
                modeString = "Easy";
                break;
            case 2:
                modeString = "Medium";
                break;
            case 3:
                modeString = "Hard";
                break;
        }
        modeText.text = "Mode: " + modeString;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneload);

    }

    public int GetMode()
    {
        int number = 10;
        switch (mode)
        {
            case 1:
                number = 5;
                modeString = "Easy";
                break;
            case 2:
                number = 10;
                modeString = "Medium";
                break;
            case 3:
                number = 15;
                modeString = "Hard";
                break;
        }
        return number;
    }
}
