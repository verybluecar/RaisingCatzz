using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        // Reload the initial scene
        SceneManager.LoadScene(0);
        
    }
}
