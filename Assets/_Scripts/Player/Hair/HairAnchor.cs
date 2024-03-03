using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairAnchor : MonoBehaviour
{
    public float lerpSpeed = 20f;
    public Vector2 partOffset = Vector2.zero;

    private Transform[] hairParts;
    private Transform hairAnchor;


    private void Awake()
    {
        hairAnchor = GetComponent<Transform>();
        hairParts = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform partToFollow = hairAnchor;

        foreach (Transform hairPart in hairParts)
        {
            if(!hairPart.Equals(hairAnchor))
            {
                Vector2 targetPosition = (Vector2)partToFollow.position + partOffset;
                Vector2 newPositionLerped = Vector2.Lerp(hairPart.position, targetPosition, Time.deltaTime * lerpSpeed);

                hairPart.position = newPositionLerped;
                partToFollow = hairPart;
            }
        }
    }
}
