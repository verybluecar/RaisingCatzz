using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatRoam : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range;
    public float interactDistance;
    public LayerMask interactLayer;

    public Transform centrePoint;

    public bool hungry;
    public bool potty;

    private GameObject foodBowl;
    private GameObject litterBox;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        foodBowl = FindNearestObjectWithTag("foodBowl");
        litterBox = FindNearestObjectWithTag("litterBox");
    }

    private void Update()
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

        if (hungry && foodBowl != null)
        {
            if (Vector3.Distance(transform.position, foodBowl.transform.position) <= interactDistance)
            {
                Debug.Log("Eating from food bowl...");
                hungry = false;
            }
            else
            {
                agent.SetDestination(foodBowl.transform.position);
            }
        }

        if (potty && litterBox != null)
        {
            if (Vector3.Distance(transform.position, litterBox.transform.position) <= interactDistance)
            {
                Debug.Log("Using litter box...");
                potty = false;
            }
            else
            {
                agent.SetDestination(litterBox.transform.position);
            }
        }
    }

    private GameObject FindNearestObjectWithTag(string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        GameObject nearestObject = null;
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject obj in objects)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance < nearestDistance)
            {
                nearestObject = obj;
                nearestDistance = distance;
            }
        }

        return nearestObject;
    }

    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
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
}
