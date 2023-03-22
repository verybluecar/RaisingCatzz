using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public Canvas ShopCanvas;
    public bool Shopping = false;

    private GameObject player;

    private mouseLook mouseLook;
    private LookStats lookStats;
    private PlayerMove playerMove;
    private Camera cameraa;
    public Canvas popupCanvas;

    private void Start()
    {
        ShopCanvas.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        cameraa = Camera.main;
        popupCanvas.enabled = false;

        mouseLook = cameraa.GetComponent<mouseLook>();
        lookStats = player.GetComponent<LookStats>();
        playerMove = player.GetComponent<PlayerMove>();
    }

    private void Update()
    {
        if (Shopping && Input.GetKeyDown(KeyCode.E))
        {
            ShopCanvas.gameObject.SetActive(!ShopCanvas.gameObject.activeSelf);
            popupCanvas.enabled = false;

            if (ShopCanvas.gameObject.activeSelf)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                mouseLook.enabled = false;
                lookStats.enabled = false;
                playerMove.enabled = false;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                popupCanvas.enabled = true;
                mouseLook.enabled = true;
                lookStats.enabled = true;
                playerMove.enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Shopping = true;
            popupCanvas.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Shopping = false;

            mouseLook.enabled = true;
            lookStats.enabled = true;
            playerMove.enabled = true;
            popupCanvas.enabled = false;
        }
    }
}




