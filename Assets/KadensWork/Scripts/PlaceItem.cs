using UnityEngine;

public class PlaceItem : MonoBehaviour
{
    public Transform handTransform;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (transform.childCount > 0)
                {
                    Transform childTransform = transform.GetChild(0);
                    childTransform.position = handTransform.TransformPoint(hitInfo.point);
                }
                else
                {
                    transform.position = handTransform.TransformPoint(hitInfo.point);
                }
            }
        }
    }
}


