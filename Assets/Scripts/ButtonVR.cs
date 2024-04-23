using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    public GameObject ballPrefab;

    GameObject presser;
    AudioSource sound;
    bool isPressed;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;

            SpawnBall();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public Transform spawnPoint; // Add the spawn point Transform

    // ... your existing Start, OnTriggerEnter, OnTriggerExit methods ...

    public void SpawnBall()
    {
        if (spawnPoint != null) // Check if a spawnPoint is assigned
        {
            GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);

            // ... (Optional customization) ...
        }
        else
        {
            Debug.LogWarning("No spawnPoint assigned! Using default spawn position.");
            // ... Your default spawn behavior here if you want ...
        }
    }
}
