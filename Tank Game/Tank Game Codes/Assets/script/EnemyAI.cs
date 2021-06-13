using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    NavMeshAgent navMeshAgent;
    Animator fsm;
    Transform player;
    public Transform rayOrigin;
    float maxCheckDistance = 10f;
    public Transform p1, p2;
    Vector3[] waypoints;
    int currentTarget;

	// Use this for initialization
	void Start () {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        fsm = GetComponent<Animator>();
        currentTarget = 0;
        waypoints = new Vector3[] { p1.position, p2.position };
        navMeshAgent.SetDestination(waypoints[currentTarget]);
	}
	
	
	void FixedUpdate () {
        float d = Vector3.Distance(player.position, transform.position);
        fsm.SetFloat("Distance", d);
       

        Vector3 dir = player.position - rayOrigin.position;
        dir = dir.normalized;
        float distanceFromWayPoint = Vector3.Distance(transform.position, waypoints[currentTarget]);
        fsm.SetFloat("distanceFromWaypoint", distanceFromWayPoint);
        //görünür mü
        Debug.DrawRay(rayOrigin.position, dir * maxCheckDistance, Color.red);
        RaycastHit hitInfo;
       if(Physics.Raycast(rayOrigin.position,dir* maxCheckDistance, out hitInfo))
        {
            if (hitInfo.transform.tag == "Player")
            {
                fsm.SetBool("isVisible", true);
            }
            else
                fsm.SetBool("isVisible", false);


        }
        else
            fsm.SetBool("isVisible", false);

    }
    public void SetNextWayPoint()
    {
        switch(currentTarget)
        {
            case 0:
                currentTarget = 1;
                break;
            case 1:
                currentTarget = 0;
                break;

        }

        navMeshAgent.SetDestination(waypoints[currentTarget]);
    }
    public void Shoot()
    {
        gameObject.GetComponent<tankShooting>().Shoot();
    }

    public void SetLookRotation()
    {
        if (!player) return;
       
        Vector3 dir = player.position - transform.position;
        dir = dir.normalized;
        Quaternion rot = new Quaternion();
        rot.SetLookRotation(dir);

        transform.rotation = Quaternion.Slerp(transform.rotation,rot,0.2f);



    }
    
    public void PatrolEnter()
    {
        navMeshAgent.SetDestination(waypoints[currentTarget]);
    }

    public void Chase()
    {
        navMeshAgent.SetDestination(player.position);
    }


}
