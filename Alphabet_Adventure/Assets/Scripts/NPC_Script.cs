using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Script : MonoBehaviour
{
    public PathEnemy path;
    private NavMeshAgent agent;
    private float waitTime;
    private int wayPointIndex;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        patrolCycle();
    }
    public void patrolCycle()
    {
        if (agent.remainingDistance < 0.2f)
        {
            anim.SetFloat("speed_npc", 0);
            waitTime += Time.deltaTime;
            if (waitTime > 3)
            {
                anim.SetFloat("speed_npc", 0.5f);
                if (wayPointIndex < path.wayPoints.Count - 1)
                {
                    wayPointIndex++;
                }
                else
                {
                    wayPointIndex = 0;
                }
                waitTime = 0;
            }
            agent.SetDestination(path.wayPoints[wayPointIndex].position);
        }
    }
}
