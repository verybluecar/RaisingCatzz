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

    private void Start()
    {
        ShopCanvas.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        cameraa = Camera.main;

        mouseLook = cameraa.GetComponent<mouseLook>();
        lookStats = player.GetComponent<LookStats>();
        playerMove = player.GetComponent<PlayerMove>();
    }

    private void Update()
    {
        if (Shopping && Input.GetKeyDown(KeyCode.E))
        {
            ShopCanvas.gameObject.SetActive(!ShopCanvas.gameObject.activeSelf);

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
        }
    }
}




