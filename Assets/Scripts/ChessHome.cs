using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessHome : MonoBehaviour
{
    public GameObject monitor;
    private void OnCollisionStay(Collision other) {
        if (other.gameObject.name == "KnightLight")
        {
            monitor.GetComponent<ProjectorOn>().isHome = true;
        }
    }
}
