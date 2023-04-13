using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxMenu : MonoBehaviour
{
    public Canvas LootBoxHolderCanvas;
    public Canvas BuyLootBoxCanvas;
    public bool canBuyLootBox;
    private randomNumber randomNumberScript;

    // Start is called before the first frame update
    void Start()
    {
        
        GameObject lootBoxShopObject = GameObject.Find("LootBoxShop");
        randomNumberScript = lootBoxShopObject.GetComponent<randomNumber>();

        
        BuyLootBoxCanvas.enabled = false;
        LootBoxHolderCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canBuyLootBox == true && Input.GetKeyDown(KeyCode.E))
        {
            
            randomNumberScript.GenerateRandomStats();

            Debug.Log("You Bought LootBox");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LootBoxShop"))
        {
            BuyLootBoxCanvas.enabled = true;
            canBuyLootBox = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("LootBoxShop"))
        {
            BuyLootBoxCanvas.enabled = false;
            canBuyLootBox = false;
        }
    }
}
