using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public Text failText;
    private Vector3 height;

    // Start is called before the first frame update
    void Start()
    {
        failText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        height = this.GetComponent<Transform>().position;
        if(Goal_Clear.gameOn && height.y <= -10.0f)
        {
            this.gameObject.SetActive(false);
            failText.enabled = true;
            Goal_Clear.gameOn = false;
        }
    }
}
