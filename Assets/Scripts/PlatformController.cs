using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform posA, posB;
    public float speed; // Make speed float in case you need finer adjustments
    Vector2 targetPos;

    void Start() // Correct capitalization
    {
        targetPos = posB.position;
    }

    void Update() // Correct capitalization
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.1f) targetPos = posB.position;
 
        if (Vector2.Distance(transform.position, posB.position) < 0.1f) targetPos = posA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
