using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Show : MonoBehaviour
{
    public Text ruleText;
    private bool showFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        ruleText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player" && showFlag)
        {
            ruleText.enabled = true;
            Invoke("hide", 3f);
            //ruleText.enabled = false;
            //showFlag = false;
        }
    }

    void hide()
    {
        ruleText.enabled = false;
        showFlag = false;
    }
    
}
