using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector2 offset;
    public float lerpSpeed = 5f;
    public float maxDistance = .5f;

    public float gravity = .1f;

    PlayerMovement movement;

    public void InitHair(PlayerMovement movement)
    {
        this.movement = movement;
        this.movement.updateHairGravity += SetGravity;
    }

    private void OnDestroy()
    {
        movement.updateHairGravity -= SetGravity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - gravity, transform.position.z);

        Vector2 limitedDist = transform.position - target.position;
        limitedDist.Normalize();
        limitedDist *= maxDistance;

        limitedDist = limitedDist + (Vector2)target.position;

        Vector2 newPositionLerped = Vector2.Lerp(limitedDist, target.position, Time.deltaTime * lerpSpeed);

        transform.position = newPositionLerped;
    }

    private void SetGravity(float newGravity)
    {
        gravity = newGravity;
    }
}
