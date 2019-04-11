using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpawner : MonoBehaviour {


    [SerializeField]
    private GameObject DotsPrefab;

    // Use this for initialization
    void Start () {
        GameObject smallDots = Instantiate(DotsPrefab, transform.position, transform.rotation);// Instantiates an instance of a small dot at each spawn point
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
