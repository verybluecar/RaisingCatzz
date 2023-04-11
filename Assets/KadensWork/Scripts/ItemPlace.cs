using UnityEngine;

public class ItemPlace : MonoBehaviour
{
    public float yOffset = 0.5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from camera to mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Set the child's position to the hit point
                Vector3 newPosition = new Vector3(hit.point.x, hit.point.y + yOffset, hit.point.z);
                transform.position = newPosition;

                // Make the object unparented
                transform.parent = null;
            }
        }
    }
}






