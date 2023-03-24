using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject canvas; // Reference to the canvas object
    public GameObject mouseLookObject; // Reference to the GameObject with the MouseLook script
    public GameObject playerMoveObject; // Reference to the GameObject with the PlayerMove script
    private bool canvasActive = false; // Flag for whether the canvas is currently active
    private bool cursorVisible = false; // Flag for whether the cursor is currently visible
    private bool cursorLocked = true; // Flag for whether the cursor is currently locked
    private MouseLook mouseLook; // Reference to the MouseLook script
    private PlayerMove playerMove; // Reference to the PlayerMove script

    private void Start()
    {
        canvas.SetActive(false);
        mouseLook = mouseLookObject.GetComponent<MouseLook>();
        playerMove = playerMoveObject.GetComponent<PlayerMove>();
    }

    void Update()
    {
        // Check if the Tab key has been pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Toggle the canvas state
            canvasActive = !canvasActive;

            // Activate or deactivate the canvas accordingly
            canvas.SetActive(canvasActive);

            // Toggle the cursor state
            cursorVisible = !cursorVisible;
            cursorLocked = !cursorLocked;

            // Set the cursor state accordingly
            Cursor.visible = cursorVisible;
            Cursor.lockState = cursorLocked ? CursorLockMode.Locked : CursorLockMode.None;

            // Enable or disable the MouseLook and PlayerMove scripts
            mouseLook.enabled = !canvasActive;
            playerMove.enabled = !canvasActive;
        }
    }
}




