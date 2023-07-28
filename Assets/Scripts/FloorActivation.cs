using UnityEngine;

public class FloorActivation : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer; // Assign the "Player" layer in the inspector
    [SerializeField] private int targetFloorsToActivate = 2; // Set the number of floors to activate

    private static int activatedFloorsCount = 0;
    private bool isPlayerOnFloor = false;
    private bool isFunctionalityActive = false;
    public GameObject winScreen;
    private GameManager gameManager;

    private void Start()
    {
        // find the GameManager script component
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & playerLayer) != 0)
        {
            isPlayerOnFloor = true;
            ActivateFloorFunctionality();
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & playerLayer) != 0)
        {
            isPlayerOnFloor = false;
            DeactivateFloorFunctionality();
        }
    }

    private void ActivateFloorFunctionality()
    {
        if (isPlayerOnFloor && !isFunctionalityActive)
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

    private void DeactivateFloorFunctionality()
    {
        if (!isPlayerOnFloor && isFunctionalityActive)
        {
            // Decrement the activated floors count
            activatedFloorsCount--;

            isFunctionalityActive = false;
            Debug.Log("Floor deactivated!");
        }
    }

    private void WinGame()
    {
        // Implement the logic to show the win screen here
        Debug.Log("You win!");

        //activates the win screen UI
         //winScreen.SetActive(true);

        //Pause the game upon win 
        //Time.timeScale = 0f;

        // Calls the LoadNextLevel method from the GameManager
        if (gameManager != null)
        {
            gameManager.LoadNextLevelWithDelay(0f);
        }

    }
}

