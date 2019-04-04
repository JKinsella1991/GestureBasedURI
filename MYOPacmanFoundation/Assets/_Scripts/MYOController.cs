using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;
using WindowsInput;
using WindowsInput.Native;


using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class MYOController : MonoBehaviour
{
    public GameObject myo = null;
    private Pose _lastPose = Pose.Unknown;

    bool onceCalled = false;

    int armPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Access the ThalmicMyo component attached to the Myo game object.
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

        


        // Check if the pose has changed since last update.
        // The ThalmicMyo component of a Myo game object has a pose property that is set to the
        // currently detected pose (e.g. Pose.Fist for the user making a fist). If no pose is currently
        // detected, pose will be set to Pose.Rest. If pose detection is unavailable, e.g. because Myo
        // is not on a user's arm, pose will be set to Pose.Unknown.
        if (thalmicMyo.pose != _lastPose)
        {
            _lastPose = thalmicMyo.pose;
            /*
            new InputSimulator().Keyboard.KeyPress(VirtualKeyCode.DOWN);
            if (Input.GetKeyDown("down"))
            {
                print("Down key was pressed");
            }
            */
            // Vibrate the Myo armband when a fist is made.
            if (thalmicMyo.pose == Pose.Fist)
            {
                thalmicMyo.Vibrate(VibrationType.Medium);
                new InputSimulator().Keyboard.KeyPress(VirtualKeyCode.SPACE);
                ExtendUnlockAndNotifyUserAction(thalmicMyo);
            }
        }

        float MYORotX = myo.transform.localRotation.eulerAngles.x;
        float MYORotY = myo.transform.localRotation.eulerAngles.y;
        /*
        if (MYORotY <= 180f && MYORotY >= 270f)
        {
            MYORotY -= 180f;
        }
        */

        if (MYORotY < 19f)
        {
            armPos = -1;
            Debug.Log(armPos);
        }
        if (MYORotY < 60f && MYORotY > 20f)
        {
            Debug.Log("Neutral");
            armPos = 0;
            onceCalled = false;
        }
        if (MYORotY > 80f)
        {
            armPos = 1;
            Debug.Log(armPos);
        }

        if (armPos == -1)
        {
            if(onceCalled == false)
            {
                new InputSimulator().Keyboard.KeyPress(VirtualKeyCode.DOWN);
                Debug.Log("DOWN");

                onceCalled = true;
            }
        }
        if (armPos == 1)
        {
            if (onceCalled == false)
            {
                new InputSimulator().Keyboard.KeyPress(VirtualKeyCode.UP);
                Debug.Log("UP");

                onceCalled = true;
            }
        }
        Debug.Log(MYORotY);

    }

    // Extend the unlock if ThalmcHub's locking policy is standard, and notifies the given myo that a user action was
    // recognized.
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
