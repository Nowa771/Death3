using UnityEngine;



public class FloorActivation : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer; // Assign the "Player" layer in the inspector
    [SerializeField] private int targetFloorsToActivate = 2; // Set the number of floors to activate

    public static int activatedFloorsCount = 0;
    private bool isFunctionalityActive = false;
    public GameObject winScreen;
    private GameManager gameManager;

    public void ResetActivatedFloorsCount()
    {
        activatedFloorsCount = 0;
    }

    private void Start()
    {
        // find the GameManager script component
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & playerLayer) != 0)
        {
            if (!isFunctionalityActive)
            {
                // Increment the activated floors count and check for the win condition
                activatedFloorsCount++;
                if (activatedFloorsCount >= targetFloorsToActivate)
                {
                    WinGame();
                }

                isFunctionalityActive = true;
                Debug.Log("Floor activated!");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & playerLayer) != 0)
        {
            if (isFunctionalityActive)
            {
                // Decrement the activated floors count
                activatedFloorsCount--;

                // Make sure activatedFloorsCount never goes below 0
                if (activatedFloorsCount < 0)
                {
                    activatedFloorsCount = 0;
                }

                isFunctionalityActive = false;
                Debug.Log("Floor deactivated!");
            }
        }
    }

    private void WinGame()
    {
        // Implement the logic to show the win screen here
        Debug.Log("You win!");

        // Reset the activated floors count when the level is completed
        activatedFloorsCount = 0;

        // Calls the LoadNextLevel method from the GameManager
        if (gameManager != null)
        {
            gameManager.LoadNextLevelWithDelay(2f);
        }
    }
}









