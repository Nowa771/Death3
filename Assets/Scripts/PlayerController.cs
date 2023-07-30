using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float movementSpeed = 10f;

    [Header("Controls")]
    [SerializeField] private KeyCode forwardKey;
    [SerializeField] private KeyCode backKey;
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode rightKey;

    private Rigidbody rb;
    private GameManager gameManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        // This code was made by Aaron.Goss as a in class toturial though i have changed the code a bit
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(forwardKey))
        {
            moveDirection += transform.forward;
        }
        if (Input.GetKey(backKey))
        {
            moveDirection -= transform.forward;
        }
        if (Input.GetKey(leftKey))
        {
            moveDirection -= transform.right;
        }
        if (Input.GetKey(rightKey))
        {
            moveDirection += transform.right;
        }

        // Normalize the moveDirection vector to prevent faster diagonal movement
        if (moveDirection != Vector3.zero)
        {
            moveDirection.Normalize();
        }

        // Apply movement to the Rigidbody
        MovePlayer(moveDirection);
    }

    private void MovePlayer(Vector3 direction)
    {
        // Calculate the desired movement vector
        Vector3 movement = direction * movementSpeed * Time.deltaTime;

        // Output the calculated movement vector for debugging
        //Debug.Log("Movement: " + movement);

        // Move the player using the Rigidbody
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        // check if a player has touched the out of map space
        if (other.CompareTag("Outside"))
        {
            // Destroy the player
            Destroy(gameObject);
        }
    }

    public void OnDestroy()
    {
        gameManager.PlayerDestroyed();
    }

    //private void WinLevel()
    //{
    //    // Call GameManager's method to load the next level with a delay
    //    gameManager.LoadNextLevelWithDelay(2f);
    //}
}
