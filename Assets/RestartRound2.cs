using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartRound2 : MonoBehaviour
{
    public Button restartButton;
    public goal goalScript;
    public GameObject loseText; // Reference to your lose text GameObject
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowButton()
    {
        restartButton.gameObject.SetActive(true);
        restartButton.interactable = true;
        loseText.SetActive(true); // Activate lose text
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(2);

    }
}
