using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitShop : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Level1");
        }
    }
}

