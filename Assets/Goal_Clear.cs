using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal_Clear : MonoBehaviour
{
    public Text goalText;
    //public Text textLose;
    public static bool gameOn;

    // Start is called before the first frame update
    void Start()
    {
        goalText.enabled = false;
        gameOn = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Target" && gameOn == true)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
            goalText.enabled = true;
            gameOn = false;
        }
    }
}
