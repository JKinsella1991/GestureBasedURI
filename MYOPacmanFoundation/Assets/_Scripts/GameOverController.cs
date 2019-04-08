using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class GameOverController : MonoBehaviour
{
    public GameObject GameOverPanel; //holds the user interface

    private GameObject myoGameObject;
    private Pose _lastPose = Pose.Unknown;

    void Start()
    {
        myoGameObject = GameObject.FindGameObjectWithTag("Myo");
    }

    // Update is called once per frame
    void Update()
    {
        ThalmicMyo thalmicMyo = myoGameObject.GetComponent<ThalmicMyo>();

        if (GameOverPanel.activeInHierarchy == true && thalmicMyo.pose == Pose.FingersSpread)
        {
            ExtendUnlockAndNotifyUserAction(thalmicMyo);
            SceneManager.LoadSceneAsync(SceneNames.MAIN_MENU);

        }
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
