using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private GameObject player;
    private NavMeshAgent agent;
    private Animator anim;
    public PathEnemy path;
    public Vector3 lastPos;
    //public GameObject debugShere;
    public GameObject Player { get=>player; }
    public NavMeshAgent Agent { get=>agent; }
    public Animator Anim { get => anim; }
    [Header("Sight Values")]
    public float fieldOfView = 85f;
    public float eyeHieght;
    public float sightdistance = 20f;
    [Header("Weapon Values")]
    public GameObject bullet;
    public Transform gunBerrel;
    [Range(0.1f,10f)]
    public float fireRate;
    [SerializeField]
    private string curentStateString;
    void Start()
    {
        stateMachine=GetComponent<StateMachine>();
        agent=GetComponent<NavMeshAgent>();
        stateMachine.initialise();
        anim=GetComponentInChildren<Animator>();
        player=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        canSeePlayer();
        curentStateString=stateMachine.currentState.ToString();
        //debugShere.transform.position=lastPos;
    }
    public bool canSeePlayer()
    {
        if(player!=null)
        {
            //if the player close enough to the enemy
            if(Vector3.Distance(transform.position,player.transform.position)<sightdistance)
            {
                Vector3 direction= player.transform.position - transform.position-(Vector3.up*eyeHieght);
                float angle= Vector3.Angle(direction,transform.forward);
                //if the player is in the field of view of the enemy
                if(angle >= -fieldOfView && angle < fieldOfView)
                {
                    Ray ray= new Ray(transform.position+(Vector3.up*eyeHieght),direction);
                    RaycastHit hit =new RaycastHit();
                    if(Physics.Raycast(ray,out hit,sightdistance))
                    {
                        if(hit.collider.gameObject.tag=="Player")
                        {
                            return true;
                        }
                    }
                    Debug.DrawRay(ray.origin,ray.direction*sightdistance,Color.red);

                }
            }
        }
        return false;
    }

}
