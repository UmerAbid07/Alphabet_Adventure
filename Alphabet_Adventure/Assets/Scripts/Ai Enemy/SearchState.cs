using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SearchState : BaseState
{
    private float searchTimer;
    private float moveTimer;
    public override void enterState()
    {
        enemy.Agent.SetDestination(enemy.lastPos);
    }
    public override void performState()
    {
        if(enemy.canSeePlayer())
        {
            stateMachine.changeState(new AttackState());
        }
        
        if (enemy.Agent.remainingDistance < enemy.Agent.stoppingDistance)
        {
            searchTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;
            if (searchTimer >10f)
            {
                stateMachine.changeState(new PatrolState());
            }
            if(moveTimer > 3)
            {
                enemy.Agent.SetDestination(enemy.transform.position + Random.insideUnitSphere * 5);
                moveTimer = 0;
            }
        }
    }
    public override void exitState()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
