using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public StateMachine stateMachine;
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get=>agent; }
    public string curentState;
    public PathEnemy path;
    
    // Start is called before the first frame update
    void Start()
    {
        stateMachine=GetComponent<StateMachine>();
        agent=GetComponent<NavMeshAgent>();
        stateMachine.initialise();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
