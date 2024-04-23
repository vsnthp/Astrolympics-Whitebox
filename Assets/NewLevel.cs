using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevel : MonoBehaviour
{
    public int nextLevelToLoad = 2; // Set the desired level index

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelToLoad);
    }
}
