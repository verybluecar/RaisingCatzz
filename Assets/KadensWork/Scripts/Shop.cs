using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Shop");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}


