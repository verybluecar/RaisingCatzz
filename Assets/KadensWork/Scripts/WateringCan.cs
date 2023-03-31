using UnityEngine;
using System.Collections;

public class WateringCan : MonoBehaviour
{
    private Animator animator;
    public float delayTime = 0.5f;
    public GameObject objectToActivate;
    private Camera playerCamera;
    public LayerMask layerMask;

    private bool isWatering = false;
    private bool isLookingAtFlowersOrGrass = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerCamera = Camera.main;
    }

    void Update()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo, Mathf.Infinity, layerMask))
        {
            if (hitInfo.collider.CompareTag("Flowers") || hitInfo.collider.CompareTag("Grass"))
            {
                isLookingAtFlowersOrGrass = true;
            }
            else
            {
                isLookingAtFlowersOrGrass = false;
            }
        }
        else
        {
            isLookingAtFlowersOrGrass = false;
        }

        if (isWatering && !isLookingAtFlowersOrGrass)
        {
            animator.SetBool("Idle1", false);
            objectToActivate.SetActive(false);
            StopCoroutine("ActivateObjectWithDelay");
            isWatering = false;
        }

        if (Input.GetMouseButtonDown(0) && isLookingAtFlowersOrGrass && !isWatering)
        {
            animator.SetBool("Idle1", true);
            StartCoroutine(ActivateObjectWithDelay());
            isWatering = true;
        }

        if (Input.GetMouseButtonUp(0) && isWatering)
        {
            animator.SetBool("Idle1", false);
            objectToActivate.SetActive(false);
            StopCoroutine("ActivateObjectWithDelay");
            isWatering = false;
        }
    }

    IEnumerator ActivateObjectWithDelay()
    {
        yield return new WaitForSeconds(delayTime);
        if (isLookingAtFlowersOrGrass)
        {
            objectToActivate.SetActive(true);
        }
        else
        {
            isWatering = false;
        }
    }
}









