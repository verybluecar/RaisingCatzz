using UnityEngine;

public class ESCMenu : MonoBehaviour
{
    public Canvas escMenuCanvas;
    public GameObject player;
    public GameObject camera;

    private bool _isOpen = false;
    private CursorLockMode _previousLockMode;

    private void Start()
    {
        // Disable the canvas on start
        escMenuCanvas.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isOpen)
            {
                // Close the menu
                CloseESCMenu();
            }
            else
            {
                // Open the menu
                OpenESCMenu();
            }
        }
    }

    private void OpenESCMenu()
    {
        // Enable the canvas
        escMenuCanvas.enabled = true;

        // Unlock and show the cursor
        Cursor.visible = true;
        _previousLockMode = Cursor.lockState;
        Cursor.lockState = CursorLockMode.None;

        // Set the menu as open
        _isOpen = true;

        // Disable player and camera movement
        player.GetComponent<PlayerMove>().enabled = false;
        camera.GetComponent<mouseLook>().enabled = false;
    }

    private void CloseESCMenu()
    {
        // Disable the canvas
        escMenuCanvas.enabled = false;

        // Lock and hide the cursor
        Cursor.visible = false;
        Cursor.lockState = _previousLockMode;

        // Set the menu as closed
        _isOpen = false;

        // Enable player and camera movement
        player.GetComponent<PlayerMove>().enabled = true;
        camera.GetComponent<mouseLook>().enabled = true;
    }
}
