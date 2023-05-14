using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] waypoints;
    public GameObject player;
    public float lookingRadius = 6;
    bool playerDetected;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.5f && playerDetected == false)
        {
            agent.destination = waypoints[Random.Range(0, waypoints.Length)].position;
        }

        if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= lookingRadius)
        {
            {
                agent.destination = player.transform.position;
                playerDetected = false;
            }
        }
        else
        {
            playerDetected = false;
        }
    }
}
