using UnityEngine;

public class ESCMenu : MonoBehaviour
{
    public Canvas escMenuCanvas;
    public GameObject player;
    public GameObject mainCamera;

    public bool isOpen = false;
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
           
            {
                // Open the menu
                OpenESCMenu();
            }
        }
    }

    public void OpenESCMenu()
    {
        // Enable the canvas
        escMenuCanvas.enabled = true;

        // Unlock and show the cursor
        Cursor.visible = true;
        _previousLockMode = Cursor.lockState;
        Cursor.lockState = CursorLockMode.None;

        // Set the menu as open
        isOpen = true;

        // Disable player and camera movement
        player.GetComponent<PlayerMove>().enabled = false;
        mainCamera.GetComponent<MouseLook>().enabled = false;
    }

    public void CloseESCMenu()
    {
        // Disable the canvas
        escMenuCanvas.enabled = false;

        // Lock and hide the cursor
        Cursor.visible = false;
        Cursor.lockState = _previousLockMode;

        // Set the menu as closed
        isOpen = false;

        // Enable player and camera movement
        player.GetComponent<PlayerMove>().enabled = true;
        mainCamera.GetComponent<MouseLook>().enabled = true;
    }
}


