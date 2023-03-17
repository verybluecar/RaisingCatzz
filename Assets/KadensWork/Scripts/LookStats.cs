using UnityEngine;

public class LookStats : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask catLayerMask;
    [SerializeField] private Canvas catCanvas;

    private void Start()
    {
        catCanvas.gameObject.SetActive(false);

    }
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, Mathf.Infinity, catLayerMask))
        {
            if (hit.collider.CompareTag("Cat"))
            {
                catCanvas.gameObject.SetActive(true);
            }
            else
            {
                catCanvas.gameObject.SetActive(false);
            }
        }
        else
        {
            catCanvas.gameObject.SetActive(false);
        }
    }
}

