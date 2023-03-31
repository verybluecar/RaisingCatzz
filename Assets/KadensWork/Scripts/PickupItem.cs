using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Transform handObject; // reference to the hand object
    public float maxDistance = 5f; // maximum distance to detect pickupable items
    public LayerMask pickupableLayer; // layer that contains pickupable items
    public Canvas pickUpCanvas; // reference to the canvas
    private Transform currentPickupItem; // reference to the current pickup item in hand

    void Start()
    {
        // Hide the pickup canvas at the start
        pickUpCanvas.enabled = false;
    }

    void Update()
    {
        // Check if there is no current pickup item in hand
        if (currentPickupItem == null)
        {
            // Raycast from camera to detect pickupable items
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxDistance, pickupableLayer))
            {
                // Check if the hit object has the "Pickupable" tag
                if (hit.collider.CompareTag("Pickupable"))
                {
                    // Show the pickup canvas
                    pickUpCanvas.enabled = true;

                    // Check if the player presses the pickup button
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        // Set the current pickup item to the hit object
                        currentPickupItem = hit.transform;

                        // Teleport the item to the hand object
                        currentPickupItem.position = handObject.position;
                        currentPickupItem.rotation = handObject.rotation;
                        currentPickupItem.parent = handObject;

                        // Make the item kinematic
                        currentPickupItem.GetComponent<Rigidbody>().isKinematic = true;

                        // Hide the pickup canvas
                        pickUpCanvas.enabled = false;
                    }
                }
                else
                {
                    // Hide the pickup canvas if the hit object is not pickupable
                    pickUpCanvas.enabled = false;
                }
            }
            else
            {
                // Hide the pickup canvas if there is no hit object
                pickUpCanvas.enabled = false;
            }
        }
        else
        {
            // Check if the current pickup item is still a child of the hand object
            if (currentPickupItem.parent == handObject)
            {
                // Check if the player drops the item
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Make the item non-kinematic
                    currentPickupItem.GetComponent<Rigidbody>().isKinematic = false;

                    // Drop the item from the hand
                    currentPickupItem.parent = null;

                    // Reset the current pickup item
                    currentPickupItem = null;
                }
            }
            else
            {
                // Make the item non-kinematic if it's no longer a child of the hand object
                currentPickupItem.GetComponent<Rigidbody>().isKinematic = false;

                // Reset the current pickup item
                currentPickupItem = null;
            }
        }
    }
}







