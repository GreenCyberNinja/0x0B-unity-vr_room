using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public GameObject door;
    public string ans = "";
    string pswd = "5913";
    public Text intxt;
 public void add(string num)
 {
    ans += num;

    intxt.text = ans;
    if (ans.Length > 3)
    {
        if (ans.Equals(pswd))
        {
            door.GetComponent<Animator>().SetBool("character_nearby", true);
        }
        else
        {
            ans = "";
        }
           
     }
 }
}
