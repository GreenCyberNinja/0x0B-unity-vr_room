using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamOffsetMan : MonoBehaviour
{
    public Transform height;
    public GameObject htbut;
    private bool isTall = false;
    // Start is called before the first frame update
    public void Tallinator()
    {
        height = this.transform;
        if (!isTall)
        {
            height.position += Vector3.up;
            isTall = true;
        }
        else
        {
            htbut.GetComponent<Image>().color = Color.red;
        }

    }


}
