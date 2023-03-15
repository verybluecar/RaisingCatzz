using UnityEngine;

public class ShopMoney : MonoBehaviour
{
    [SerializeField] private CatCounter catCounter;
    [SerializeField] private float amountToSubtract = 10f;

    public void SubtractMoney()
    {
        catCounter.SubtractMoney(amountToSubtract);
    }
}

