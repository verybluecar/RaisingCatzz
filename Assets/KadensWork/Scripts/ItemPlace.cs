using UnityEngine;

public class ItemPlace : MonoBehaviour
{
    public Transform handObjectTransform;
    public LayerMask layerMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, layerMask))
            {
                if (hit.collider.transform.IsChildOf(handObjectTransform))
                {
                    Transform spawnedObjectTransform = handObjectTransform.GetChild(0);
                    spawnedObjectTransform.SetParent(null);
                    spawnedObjectTransform.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
        }
    }
}
