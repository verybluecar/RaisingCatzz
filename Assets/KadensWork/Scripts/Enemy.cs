using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float lookRadius = 10f;
    public float attackDistance = 2f;

    private Transform target;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        // Find player object by tag
        target = GameObject.FindGameObjectWithTag("Player").transform;

        // Get reference to NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate distance to player
        float distance = Vector3.Distance(target.position, transform.position);

        // If player is within look radius
        if (distance <= lookRadius)
        {
            // Set destination to player position
            agent.SetDestination(target.position);

            // If player is within attack distance
            if (distance <= attackDistance)
            {
                // Attack the player
                Attack();
            }
        }
        else
        {
            // Roam around
            Roam();
        }
    }

    void Roam()
    {
        // Generate a random destination within 10 units
        Vector3 randomDirection = Random.insideUnitSphere * 10f;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas);

        // Set destination to random position
        agent.SetDestination(hit.position);
    }

    void Attack()
    {
        // Stop moving
        agent.isStopped = true;

        // Attack the player (placeholder code)
        Debug.Log("Attacking player!");
    }

    // Draw the look radius gizmo in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
