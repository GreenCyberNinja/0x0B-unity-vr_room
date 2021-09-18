using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectorOn : MonoBehaviour
{
    public GameObject strtbut;
    public GameObject particle;
    public bool isHome;
    public void projOn()
    {
        if (!isHome)
            strtbut.GetComponent<Image>().color = Color.red;
        else
            particle.SetActive(true);
    }
}
