using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    static AudioManager instance = null;

    //Keep the audio playing when navigating to a different scene
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}