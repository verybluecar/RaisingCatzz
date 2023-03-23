using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitch : MonoBehaviour
{
    public Canvas canvas;

    private GameObject player;
    private GameObject camera;

    private void Start()
    {
        // Deactivate the canvas on start
        canvas.gameObject.SetActive(false);

        // Find the player and camera objects automatically
        player = GameObject.FindGameObjectWithTag("Player");
        camera = Camera.main.gameObject;
    }

    public void ActivateCanvas()
    {
        // Activate the canvas when the first button is pressed
        canvas.gameObject.SetActive(true);

        // Disable player and camera movement
        player.GetComponent<PlayerMove>().enabled = false;
        camera.GetComponent<mouseLook>().enabled = false;
    }

    public void DeactivateCanvas()
    {
        // Deactivate the canvas when the second button is pressed
        canvas.gameObject.SetActive(false);

        // Enable player and camera movement
        
    }
}


