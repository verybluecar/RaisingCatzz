using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 


public class CatRoam : MonoBehaviour 
{
    public NavMeshAgent agent;
    public float range; 

    public Transform centrePoint;

    public bool hungry;
    public GameObject foodBowl;

    public bool potty;
    public GameObject litterbox;

    void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();
        foodBowl = GameObject.Find("foodBowl");
        litterbox = GameObject.Find("LitterBox");
        
    }


    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) 
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) 
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); 
                agent.SetDestination(point);    
            }
        }
        
        if (hungry == true)
        {
            agent.SetDestination(foodBowl.transform.position);
            StartCoroutine(ResetHungry());
        }

        if (potty == true)
        {
            agent.SetDestination(litterbox.transform.position);
            
        }
        

    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) 
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    IEnumerator ResetHungry()
    {
        yield return new WaitForSeconds(5f);
        hungry = false;
    }
}