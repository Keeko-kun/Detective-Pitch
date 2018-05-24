using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class SceneSwitcher : MonoBehaviour {
    public string StartingGame = "";
    public float buttonOffset = 20f;
    public Toggle radioButton;
    public ToggleGroup radioGroup;
    public GameMode[] Modes;
    private List<Toggle> radioButtons = new List<Toggle>();

    private void Start() {
        InitializeToggles();
    }

    private void InitializeToggles() {
        radioButton.group = radioGroup;
        for (int g = 0; g < Modes.Length; g++) {
            RectTransform groupTransform = radioGroup.GetComponent<RectTransform>();
            Vector3 position = new Vector3(groupTransform.position.x, groupTransform.position.y - buttonOffset * g);
            Toggle t = Instantiate(radioButton, position, Quaternion.identity, radioGroup.transform);
            radioButtons.Add(t);
        }
    }

    public void StartGame() { SceneManager.LoadScene(StartingGame); }
    public void ExitApplication() { Application.Quit(); }

}

[System.Serializable]
public struct GameMode {
    public string Name;
    public string SceneName;
}
