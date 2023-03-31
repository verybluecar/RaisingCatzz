using UnityEngine;
using TMPro;

public class Bed : MonoBehaviour
{
    // References
    public LightingManager lightingManager;
    public GameObject sleepCanvas;
    public TMP_Text daysText;
    public GameObject playerObject;
    public Transform playerBedLocation;
    public float sleepDelay = 3f;

    private bool canSleep = false;
    private int daysSlept = 0;



    public void Start()
    {
        // Set canvas and text to inactive
        sleepCanvas.SetActive(false);
        daysText.gameObject.SetActive(true);

        // Find player object by tag
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        // Check if player can sleep and E key is pressed
        if (canSleep && Input.GetKeyDown(KeyCode.E))
        {
            if (lightingManager.TimeOfDay >= 18.5f && lightingManager.TimeOfDay <= 24f)
            {
                // Disable player controls
                playerObject.GetComponent<PlayerMove>().enabled = false;

                // Teleport player to bed
                playerObject.transform.position = playerBedLocation.position;
                playerObject.transform.rotation = playerBedLocation.rotation;

                // Disable sleep canvas
                sleepCanvas.SetActive(false);

                // Wait for sleep delay and enable player controls
                Invoke("EnablePlayerControls", sleepDelay);

                // Increment days slept and update text
                daysSlept++;
                daysText.text = "Days: " + daysSlept;

                // Set time to 8
                lightingManager.TimeOfDay = 8f;

                
            }
        }
    }

    void EnablePlayerControls()
    {
        playerObject.GetComponent<PlayerMove>().enabled = true;
    }

    // When player enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Show sleep canvas
        if (lightingManager.TimeOfDay >= 18.5f)
        {
            sleepCanvas.SetActive(true);
        }

        // Set canSleep to true
        canSleep = true;
    }

    // When player exits the trigger zone
    private void OnTriggerExit(Collider other)
    {
        // Hide sleep canvas
        sleepCanvas.SetActive(false);

        // Set canSleep to false
        canSleep = false;
    }
}







