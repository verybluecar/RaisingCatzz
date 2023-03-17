using UnityEngine;
using System.Collections;

public class CatController : MonoBehaviour
{
    [SerializeField] private float roamRadius = 15f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private float maxJumpDistance = 5f;
    [SerializeField] private AudioClip meowClip;

    private Vector3 targetPosition;
    private Rigidbody rb;

    private void Start()
    {
        targetPosition = GetRandomPositionWithinRoamRadius();
        StartCoroutine(PlayMeowEveryMinute());
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 directionToTarget = (targetPosition - transform.position).normalized;
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            // if about to collide with a wall, turn away from the wall
            if (hit.collider.CompareTag("Wall"))
            {
                targetPosition = GetRandomPositionWithinRoamRadius();
                return;
            }
        }

        if (IsGrounded() && distanceToTarget <= maxJumpDistance)
        {
            // if about to fall off an edge, turn away from the edge
            if (!Physics.Raycast(transform.position, -transform.up, 0.5f))
            {
                targetPosition = GetRandomPositionWithinRoamRadius();
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            targetPosition = transform.position;
        }

        if (distanceToTarget > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
        }

        if (distanceToTarget < 0.1f)
        {
            targetPosition = GetRandomPositionWithinRoamRadius();
        }
    }

    private Vector3 GetRandomPositionWithinRoamRadius()
    {
        Vector2 randomCircle = Random.insideUnitCircle * roamRadius;
        Vector3 randomPosition = new Vector3(randomCircle.x, 0, randomCircle.y);
        return transform.position + randomPosition;
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f))
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, roamRadius);
    }

    public void SetDestination(Vector3 destination)
    {
        targetPosition = destination;
    }

    private IEnumerator PlayMeowEveryMinute()
    {
        while (true)
        {
            yield return new WaitForSeconds(60f);
            AudioSource.PlayClipAtPoint(meowClip, transform.position);
        }
    }
}





