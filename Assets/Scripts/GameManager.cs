using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int startingSceneIndex;
    private bool isPlayerDestroyed = false;
    private FloorActivation[] floorActivations;

    private void Start()
    {
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
        floorActivations = FindObjectsOfType<FloorActivation>();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void PlayerDestroyed()
    {
        isPlayerDestroyed = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(startingSceneIndex);
    }

    // Method to load the next level with a delay
    public void LoadNextLevelWithDelay(float delayInSeconds)
    {
        StartCoroutine(LoadNextLevelAfterDelay(delayInSeconds));
    }

    // Coroutine for the delay before loading the next level
    private System.Collections.IEnumerator LoadNextLevelAfterDelay(float delayInSeconds)
    {
        // Pause the coroutine for the specified duration
        yield return new WaitForSeconds(delayInSeconds);

        // Load the next level scene
        SceneManager.LoadScene(startingSceneIndex + 1);
    }

    private void Update()
    {
        if (isPlayerDestroyed)
        {
            
            RestartGame();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if a new scene has been loaded and reset the activatedFloorsCount
        foreach (FloorActivation floorActivation in floorActivations)
        {
            floorActivation.ResetActivatedFloorsCount();
        }
    }
}
 






