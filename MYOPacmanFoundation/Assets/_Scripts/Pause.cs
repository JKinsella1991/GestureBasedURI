using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;
using WindowsInput.Native;
using WindowsInput;

public class Pause : MonoBehaviour
{
    public static bool GamePause = false;

    public GameObject PauseMenuPanel; //holds the user interface

    private GameObject myoGameObject;
    private Pose _lastPose = Pose.Unknown;

    AudioSource m_MyAudioSource;

    void Start()
    {
        myoGameObject = GameObject.FindGameObjectWithTag("Myo");

    }
    // Update is called once per frame
    void Update()
    {

        ThalmicMyo thalmicMyo = myoGameObject.GetComponent<ThalmicMyo>();

        if (thalmicMyo.pose != _lastPose)
        {
            _lastPose = thalmicMyo.pose;

            if (thalmicMyo.pose == Pose.DoubleTap)
            {   
                ExtendUnlockAndNotifyUserAction(thalmicMyo);
                if (GamePause == true)
                {
                    if (thalmicMyo.pose == Pose.DoubleTap)
                    {
                        ResumeGame();// Resume Game
                    }
                    if (thalmicMyo.pose == Pose.FingersSpread)
                    {
                        QuitGame();// Quit Game
                    }



                }
                else
                    PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        //Debug.Log("test");
        //when pause want to set the pauseGame = true
        PauseMenuPanel.SetActive(true);// activates the pause menu
        Time.timeScale = 0.0f;// freezes the game
        GamePause = true;
    }

    public void ResumeGame()
    {
        PauseMenuPanel.SetActive(false);// deactivates the pause menu
        Time.timeScale = 1.0f;// resumes the game
        GamePause = false;
    }

    public void QuitGame()
    {
        Debug.Log("Main menu loaded");
        SceneManager.LoadSceneAsync(SceneNames.MAIN_MENU);// Back to main menu
    }

    void ExtendUnlockAndNotifyUserAction(ThalmicMyo myo)
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (hub.lockingPolicy == LockingPolicy.Standard)
        {
            myo.Unlock(UnlockType.Timed);
        }

        myo.NotifyUserAction();
    }
}