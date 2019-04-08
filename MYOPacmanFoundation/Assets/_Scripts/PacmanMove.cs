using UnityEngine;
using System.Collections;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;
using WindowsInput.Native;
using WindowsInput;



public class PacmanMove : MonoBehaviour
{
    public float speed = 0.004f;
    Vector2 dest = Vector2.zero;

    private GameObject myoGameObject;
    private Pose _lastPose = Pose.Unknown;

    AudioSource m_MyAudioSource;

    void Start()
    {
        dest = transform.position;
        myoGameObject = GameObject.FindGameObjectWithTag("Myo");

    }

    void FixedUpdate()
    {
        //Myo rotation logic
        //float myoRotX = myo.transform.localRotation.eulerAngles.x;
        //float myoRotY = myo.transform.localRotation.eulerAngles.y;

        // Move closer to Destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        ThalmicMyo thalmicMyo = myoGameObject.GetComponent<ThalmicMyo>();


        // Check for Input if not moving
        if ((Vector2)transform.position == dest)
            if (thalmicMyo.pose != _lastPose)
            {
                _lastPose = thalmicMyo.pose;

                // Vibrate the Myo armband when a fist is made.
                if (thalmicMyo.pose == Pose.WaveOut)
                {
                    thalmicMyo.Vibrate(VibrationType.Short);
                    new InputSimulator().Keyboard.KeyPress(VirtualKeyCode.RIGHT);
                    ExtendUnlockAndNotifyUserAction(thalmicMyo);
                }
                if (thalmicMyo.pose == Pose.WaveIn)
                {
                    thalmicMyo.Vibrate(VibrationType.Short);
                    new InputSimulator().Keyboard.KeyPress(VirtualKeyCode.LEFT);
                    ExtendUnlockAndNotifyUserAction(thalmicMyo);
                }

                //if (myoGameObject.transform.rotation.z > 60)
                if (thalmicMyo.pose == Pose.Fist)
                {
                    thalmicMyo.Vibrate(VibrationType.Short);
                    new InputSimulator().Keyboard.KeyPress(VirtualKeyCode.UP);
                    ExtendUnlockAndNotifyUserAction(thalmicMyo);
                }
                //if (myoGameObject.transform.rotation.z < 20)
                if (thalmicMyo.pose == Pose.FingersSpread)
                {
                    thalmicMyo.Vibrate(VibrationType.Short);
                    new InputSimulator().Keyboard.KeyPress(VirtualKeyCode.DOWN);
                    ExtendUnlockAndNotifyUserAction(thalmicMyo);
                }
            }

        if (Input.GetKey(KeyCode.UpArrow))
            dest = (Vector2)transform.position + Vector2.up;
        if (Input.GetKey(KeyCode.RightArrow))
            dest = (Vector2)transform.position + Vector2.right;
        if (Input.GetKey(KeyCode.DownArrow))
            dest = (Vector2)transform.position - Vector2.up;
        if (Input.GetKey(KeyCode.LeftArrow))
            dest = (Vector2)transform.position - Vector2.right;

        // Animation Parameters
        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);

     
    }

    bool valid(Vector2 dir)
    {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
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