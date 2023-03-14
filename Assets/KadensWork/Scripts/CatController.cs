using UnityEngine;

public class CatController : MonoBehaviour
{
    [SerializeField] private float roamRadius = 15f; // the radius the cat should roam within
    [SerializeField] private float moveSpeed = 3f; // the speed at which the cat should move
    [SerializeField] private float rotateSpeed = 5f; // the speed at which the cat should rotate
    private Vector3 targetPosition; // the position the cat is currently moving towards

    private void Start()
    {
        targetPosition = GetRandomPositionWithinRoamRadius();
    }

    private void Update()
    {
        // calculate the direction and distance to the target position
        Vector3 directionToTarget = (targetPosition - transform.position).normalized;
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        // rotate towards the target position
        if (distanceToTarget > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
        }

        // move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // if we've reached the target position, set a new one
        if (distanceToTarget < 0.1f)
        {
            targetPosition = GetRandomPositionWithinRoamRadius();
        }
    }

    // get a random position within the roam radius
    private Vector3 GetRandomPositionWithinRoamRadius()
    {
        Vector2 randomCircle = Random.insideUnitCircle * roamRadius;
        Vector3 randomPosition = new Vector3(randomCircle.x, 0, randomCircle.y);
        return transform.position + randomPosition;
    }

    // draw the roam radius gizmo in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, roamRadius);
    }

    public void SetDestination(Vector3 destination)
    {
        targetPosition = destination;
    }

}



