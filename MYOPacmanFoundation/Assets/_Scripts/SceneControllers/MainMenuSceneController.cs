using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class MainMenuSceneController : MonoBehaviour
{
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
}
