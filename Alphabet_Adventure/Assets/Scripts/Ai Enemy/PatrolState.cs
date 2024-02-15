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
        if(enemy.canSeePlayer())
        {
            stateMachine.changeState(new AttackState());

            enemy.Anim.SetTrigger("PlayerDetected");
        }
    }
    public override void exitState()
    {

    }
    public void patrolCycle()
    {
        if(enemy.Agent.remainingDistance<0.2f)
        {
            enemy.Anim.SetFloat("C_Speed", 0);
            waitTime += Time.deltaTime;
            if (waitTime > 3)
            {
                enemy.Anim.SetFloat("C_Speed", 1);
                if (wayPointIndex < enemy.path.wayPoints.Count - 1)
                {
                    wayPointIndex++;
                }
                else
                {
                    wayPointIndex = 0;
                }
                waitTime = 0;
            }
            enemy.Agent.SetDestination(enemy.path.wayPoints[wayPointIndex].position);
        }
    }
}

