using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Text timerText;
    private bool timerStarted = false;
    private float startTime;

    // Update is called once per frame
    void Update()
    {
        // Check if the timer has started
        if (timerStarted)
        {
            // Calculate elapsed time since start
            float elapsedTime = Time.time - startTime;

            // Format the elapsed time into minutes and seconds
            string minutes = ((int)elapsedTime / 60).ToString("00");
            string seconds = (elapsedTime % 60).ToString("00");

            // Update the timer text
            timerText.text = minutes + ":" + seconds;
        }
    }

    public void StartTimer()
    {
        // Set the flag to indicate that timer has started
        timerStarted = true;

        // Record the start time
        startTime = Time.time;
    }
}