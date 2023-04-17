using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;

    private bool gameOver = false;

    private void Start()
    {
        // Deactivate the game over canvas at the start of the game
        gameOverCanvas.SetActive(false);
    }

    private void Update()
    {
        // Call the CheckForCats method every frame
        CheckForCats();

        if (gameOver)
        {
            // Disable everything except the mouse
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }

    private void CheckForCats()
    {
        if (GameObject.FindGameObjectsWithTag("Cat").Length == 0)
        {
            // Activate the game over canvas
            gameOverCanvas.SetActive(true);
            gameOver = true;
        }
    }
}

