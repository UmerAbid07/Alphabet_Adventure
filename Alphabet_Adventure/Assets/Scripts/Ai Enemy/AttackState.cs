using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    public float moveTimer;
    public float loseTimer;
    public float shotTimer;
    public override void enterState()
    {
        
    }
    public override void performState()
    {
        if (enemy.canSeePlayer())
        {
            loseTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer+= Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            if (shotTimer > enemy.fireRate)
            {
                shoot();
            }
            if (moveTimer > Random.Range(5, 8))
            {
                enemy.Agent.SetDestination(enemy.transform.position + Random.insideUnitSphere * 5);
                moveTimer = 0;
            }
            enemy.lastPos = enemy.Player.transform.position;
        }
        else
        {
            loseTimer += Time.deltaTime;
            if (loseTimer > 5)
            {
                //in this it could be search state
                stateMachine.changeState(new SearchState());
                enemy.Anim.SetBool("PlayerChase", true);
            }
        }
    }
    public override void exitState()
    {
        
    }
    void shoot()
    {
        GameObject bullet= GameObject.Instantiate(enemy.bullet, enemy.gunBerrel.position, enemy.transform.rotation);
        //Bullet force

        Debug.Log("Shooting");
        shotTimer = 0;  
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
