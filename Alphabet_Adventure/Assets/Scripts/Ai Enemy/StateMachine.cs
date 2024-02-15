using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState currentState;
    //property to set the current state
    public void initialise()
    {
        
        changeState(new PatrolState());
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.performState();
        }
    }
    public void changeState(BaseState newState)
    {
        if(currentState != null)
        {
            currentState.exitState();
        }
        //assigning the new state to the current state
        currentState = newState;
        //if the current state(newState) is not null, set the state machine and enemy
        if(currentState != null)
        {
            //set up new state
            currentState.stateMachine = this;
            currentState.enemy = GetComponent<Enemy>();
            currentState.enterState();
        }
        
    }
}
