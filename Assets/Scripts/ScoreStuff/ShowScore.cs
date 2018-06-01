using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowScore : MonoBehaviour {

    public UnityEngine.UI.Text score;

    private void Start()
    {
        float totalScore = PlayerPrefs.GetFloat("score");
        int rounds = PlayerPrefs.GetInt("rounds");

        float scores = totalScore / (float)rounds;

        score.text = scores.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu-Test");
    }

}
