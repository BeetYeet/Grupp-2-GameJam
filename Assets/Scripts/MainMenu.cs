using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
        print("Quit Works");
    }
    public void LevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void HelpScene()
    {
        SceneManager.LoadScene("HelpScene");
    }
    public void SettingScene()
    {
        SceneManager.LoadScene("Settings");
    }
    public void QuitToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
