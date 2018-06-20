using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    static private int mode;
    private string modeString;
    public UnityEngine.UI.Text modeText;
	private int sceneload;
    public int sceneloadEasy;
	public int sceneloadMedium;

	// Use this for initialization
	void Start ()
	{
	    mode = 2;
		sceneload = sceneloadMedium;
	    modeString = "Standard";
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
				modeString = "Standard";
				sceneload = sceneloadEasy;
                break;
			case 2:
				modeString = "Situations";
				sceneload = sceneloadMedium;
                break;
        }
        PlayerPrefs.SetString("difficulty", modeString);
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
                modeString = "Standard";
                break;
            case 2:
                number = 10;
                modeString = "Situations";
                break;
        }
        return number;
    }
}
