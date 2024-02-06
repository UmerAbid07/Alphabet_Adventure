using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PatrolState : BaseState
{
    public int wayPointIndex;
    public float waitTime;
    public override void enterState()
    {

    }
    public override void performState()
    {
        patrolCycle();
    }
    public override void exitState()
    {

    }
    public void patrolCycle()
    {
        if(enemy.Agent.remainingDistance<0.2f)
        {
            if (wayPointIndex < enemy.path.wayPoints.Count - 1)
            {
                wayPointIndex++;
            }
            else
            {
                wayPointIndex = 0;
            }
            enemy.Agent.SetDestination(enemy.path.wayPoints[wayPointIndex].position);
        }
    }
}

