using UnityEngine;
using UnityEngine.UI;

public class TryAgainButton : MonoBehaviour
{
    public Button tryAgainButton;  // Assign the Try Again button in the Inspector
    public goal goalScript;        // Assign your goal script in the Inspector

    void Start()
    {
        tryAgainButton.gameObject.SetActive(false); // Hide the button initially
        tryAgainButton.interactable = false;        // Make it unclickable initially
        tryAgainButton.onClick.AddListener(OnTryAgainClicked);
    }

    public void ShowButton()
    {
        tryAgainButton.gameObject.SetActive(true);
        tryAgainButton.interactable = true;  // Make it clickable
    }

    void OnTryAgainClicked()
    {
        if (goalScript != null) {
            goalScript.RestartRound(); // Call the restart function in your 'goal' script
        } else {
            Debug.LogError("goalScript is not assigned in TryAgainButton!");
        }
        tryAgainButton.gameObject.SetActive(false);
        tryAgainButton.interactable = false; 
    }
}
