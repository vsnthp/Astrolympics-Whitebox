using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI; // Corrected namespace for UI components
using TMPro;

public class goal : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb;

    // Variable to keep track of collected "PickUp" objects.
    private int count;

    // UI text component to display count of "PickUp" objects collected.
    public TextMeshProUGUI countText;

    // UI object to display in a winning text.
    public GameObject winTextObject;

    // UI text component to display timer.
    public TextMeshProUGUI timerText;

    // Variable to store the remaining time in seconds.
    public float Timer = 60f;

    private float timeLeft;

    // Variable to store the game state.
    public bool isGameOver = false;

    // Image component to display lives. Changed from SpriteRenderer to Image.
    public Image livesImage;

    // Variable to store the number of lives left.
    public int livesLeft;

    // Array to hold sprites representing different damage levels of the Earth
    public Sprite[] livesSprites;

    // Add a public Button variable to reference the StartButton.
    public Button startButton;

    // Add a boolean variable to track whether the game has started.
    private bool gameStarted = false;

    public Button tryAgainButton; // Reference to the Try Again Button
    private TryAgainButton tryAgainButtonScript;

    public GameObject loseText;

    public Button restartButton;

    public Button newLevelButton;

    private void Awake()
    {
        timeLeft = Timer;
        // Hook up the StartButton onClick event to the StartGame method.
        startButton.onClick.AddListener(StartGame);

        // Get the TryAgainButton script component
        tryAgainButtonScript = tryAgainButton.GetComponent<TryAgainButton>();
}


    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();

        // Initialize count to zero.
        count = 0;

        // Update the count display.
        SetCountText();

        // Initially set the win text to be inactive.
        winTextObject.SetActive(false);

        // Initially set the lose text to be inactive.
        loseText.SetActive(false);

        // Set the initial timer text to the timeLeft value, formatted as a whole number.
        timerText.text = timeLeft.ToString("F0");

        livesLeft = 4; // Initaialize lives to 4 

        // Load the initial Earth sprite 
        //if (livesSprites.Length > 0 && livesLeft < livesSprites.Length)
        // {
        //    livesImage.sprite = livesSprites[livesLeft];
        // }



    }


    // Update is called once per frame.
    void Update()
    {
        if (gameStarted && !isGameOver) // Check if the game has started and is not over.
        {
            // Subtract the time from the timeLeft value only if the game has started.
            timeLeft -= Time.deltaTime;
            timerText.text = timeLeft.ToString("F0"); // Update the timer text.

            if (timeLeft <= 0 && count < 5)
            { // Check if time's up and score isn't met
                LoseLife();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    // Function to update the displayed count of "PickUp" objects collected.
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 5)
        {
            winTextObject.SetActive(true);
            newLevelButton.gameObject.SetActive(true); // Show the new level button
        }
    }

    // Function to handle the lives mechanic.
    void LoseLife()
    {


        livesLeft--; 
        Debug.Log("LoseLife() called! Lives left: " + livesLeft);



        int spriteIndex = livesSprites.Length - livesLeft - 1;
        livesImage.sprite = livesSprites[spriteIndex];


        if (livesLeft >= 1 && spriteIndex >= 0 && spriteIndex < livesSprites.Length) // Added check to avoid index out of range
        {
            

            Debug.Log(spriteIndex);
            // Reset the timer       
            gameStarted = false; // Pause the game logic

            tryAgainButtonScript.ShowButton();  // Show the Try Again Button
            timeLeft = Timer;


        }

        if (livesLeft <= 0)
        {
           GameOver();
        }
    }


    void GameOver()
    {
        isGameOver = true;
        timerText.text = "Game Over";

        // Activate Lose Text
        if (loseText != null)
        {
            loseText.SetActive(true);
        }

        restartButton.gameObject.SetActive(true);
    }

    // Add a method to handle the StartButton click.
    void StartGame()
    {
        if (!gameStarted)
        {
            gameStarted = true;
            // Additional initialization or actions when the game starts can be added here.

            // Deactivate the StartButton GameObject.
            startButton.gameObject.SetActive(false);

        }
    }

    public void RestartRound()
    {
        //livesLeft = 4;  // Reset lives 
        // ... Any other restart setup you need, e.g.,  resetting positions, variables ...

        timeLeft = Timer;     // Reset the timer
        timerText.text = timeLeft.ToString("F0");  // Update the timer display

        gameStarted = true; // Mark the game as started again
    }

}