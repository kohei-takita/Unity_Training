using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class WolkAround : MonoBehaviour
{
    public Transform[] points;
    private int desPoint = 0;
    private NavMeshAgent agent;
    public GameObject target_player;
    private bool inArea = false;
    public float chaspeed = 0.05f;
    public Color origColor;

    public Text failText;

    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        failText.enabled = false;
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }

        if(target_player.activeInHierarchy == false)
        {
            GetComponent<Renderer>().material.color = origColor;
        }

        if (inArea && target_player.activeInHierarchy == true)
        {
            agent.destination = target_player.transform.position;
            EneChasing();
        }

    }

    void GotoNextPoint()
    {
        if (points.Length == 0) return;
        agent.destination = points[desPoint].position;
        desPoint = (desPoint + 1) % points.Length;
    }

    public void EneChasing()
    {
        transform.position += transform.forward * chaspeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inArea = true;
            target_player = other.gameObject;
            GetComponent<Renderer>().material.color = new Color(255f, 0f, 0f, 0f);
            EneChasing();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inArea = false;
            GetComponent<Renderer>().material.color = origColor;
            GotoNextPoint();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player" && Goal_Clear.gameOn)
        {
            explosion.transform.position = other.transform.position;
            explosion.Play();
            other.gameObject.SetActive(false);
            failText.enabled = true;
            Goal_Clear.gameOn = false;
        }
    }


}
