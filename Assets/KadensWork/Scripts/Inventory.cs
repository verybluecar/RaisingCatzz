using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;
    private bool isOpen = false;

    private void Start()
    {
        inventoryUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            inventoryUI.SetActive(isOpen);
        }
    }
}

