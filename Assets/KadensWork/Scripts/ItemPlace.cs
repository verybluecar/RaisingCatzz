using UnityEngine;

public class ItemPlace : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from camera to mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object is on the "Ground" layer
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    // Loop through all child objects of this object
                    foreach (Transform child in transform)
                    {
                        // Set the child's position to the hit point
                        child.position = hit.point;

                        // Make the child object unparented
                        child.parent = null;
                    }
                }
            }
        }
    }
}



