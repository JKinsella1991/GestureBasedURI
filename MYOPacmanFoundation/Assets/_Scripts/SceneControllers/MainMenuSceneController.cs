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

        SceneManager.LoadSceneAsync(SceneNames.LEVEL_NAME);
    }

    public void QuitOnClick()
    {
        Debug.Log("Quit Application");
        Application.Quit();
    }

    public void ControlsOnClick()
    {
        ControlsPanel.SetActive(true);// activates the controls panel
    }
}
