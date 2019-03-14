using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireFrame : MonoBehaviour {

    // draw a circle when the spawnpoint is drawn at design time
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.02f);
    }
}
