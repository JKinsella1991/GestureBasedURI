using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class MainMenuSceneController : MonoBehaviour
{
    public GameObject ControlsPanel; //holds the user interface

    // == OnClick events ==
    public void PlayOnClick()
    {
        SceneManager.LoadSceneAsync(SceneNames.LEVEL_NAME);// Loads up the game level
    }

    public void QuitOnClick()
    {
        Debug.Log("Quit Application");// Unity doesn't allow a quit unlees it's in a SDK so for testing
        Application.Quit();// Quits the application
    }

    public void ControlsOnClick()
    {
        ControlsPanel.SetActive(true);// Activates the controls panel
    }
}
