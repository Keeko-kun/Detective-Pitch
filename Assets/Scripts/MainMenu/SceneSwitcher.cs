using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour {
    public string StartingGame = "";
    public Toggle radioButton;
    public ToggleGroup radioGroup;
    public List<GameMode> Modes = new List<GameMode>();

    private void Start() {
        InitializeToggles();
    }

    private void InitializeToggles() {
        radioButton.group = radioGroup;
        for (int g = 0; g < Modes.Count; g++) {
            
        }
    }

    public void StartGame() { SceneManager.LoadScene(StartingGame); }
    public void ExitApplication() { Application.Quit(); }

}

public struct GameMode {
    public string Name;
    public string SceneName;
}
