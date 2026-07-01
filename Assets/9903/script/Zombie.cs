using System;
using UnityEngine;
using UnityEngine.AI;

public class Zombie:MonoBehaviour
{
    private NavMeshAgent m_Agent;

    private Transform player;
    
    public void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        m_Agent.SetDestination(player.position);
    }
}
