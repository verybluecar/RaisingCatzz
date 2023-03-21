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
                transform.position = handTransform.TransformPoint(hitInfo.point);
            }
        }
    }
}


