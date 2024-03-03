using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector2 offset;
    public float lerpSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        Vector2 newPositionLerped = Vector2.Lerp(transform.position, target.position, Time.deltaTime * lerpSpeed) + offset;
        transform.position = newPositionLerped;
    }
}
